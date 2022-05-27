package controls;

import java.io.File;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import models.RouteLocation;
import utility.Constants;
import views.PrintLocation;

public class Moved {
	private RouteLocation location;
	private PrintLocation print;
	
	public Moved(RouteLocation location, PrintLocation print) {
		this.location = location;
		this.print = print;
	}

	public void moveController(String inputCommand) {
		//move a.txt b.txt 1번 
		if(inputCommand.contains("move ") && !inputCommand.contains("\\")) MoveFileCurrentLocationToCurrentLocation(inputCommand);  //move a.txt b.txt
		// move\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt 4번 
		else if(checkBlankAndSlash(inputCommand, " \\") == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {
			MoveFileNewLocationToNewLocation(inputCommand);
			System.out.println("44444");
		}
		// move a.txt users\\user\onedrive\desktop\b.txt 2번 
		else if(blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {
			MoveFileCurrentLocationToDestinationLocation(inputCommand);
			System.out.println("22222222");
		}		
		// move\\users\\user\onedrive\desktop\a.txt b.txt 3번
		// move\\users\\user\desktop\a.txt 5번
		else System.out.println("55555");
		
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	private void MoveFileCurrentLocationToCurrentLocation(String inputCommand) {
		String slicedSentence[];
		slicedSentence = sliceSentence(inputCommand);
		
		File oldfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

		if(oldfile.renameTo(newfile)){
			print.printMoveFileSucessOrFail("1개 파일을 이동했습니다.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("지정된 파일을 찾을 수 없습니다.", !Constants.IS_SUCESS);
		}
	}
	
	
	private void MoveFileCurrentLocationToDestinationLocation(String inputCommand) { // 현재 위치에서 데스크탑에 b.txt으로 파일 이동
		String file =  extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt 추출
		String route = extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ 추출
		String fileAndLocation[];

		fileAndLocation = sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, 경로 저장
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // 디렉토리 위치
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // 현재위치 + 파일
		File newFile = new File(newLocation + "\\" + file); // 지정위치 + 파일
		
		if(newLocation.isDirectory() && oldFile.renameTo(newFile)) { // 경로 맞고 파일 이동 성공했으면
			print.printSentence("파일을 이동하였습니다.");
		}
		else {
			print.printSentence("지정된 경로를 찾을 수 없습니다.\r\n"
							+ "     0개 파일을 이동했습니다.");
		}		
	}
	
	
	private void MoveFileNewLocationToNewLocation(String inputCommand) {
		String files[] = sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinaionFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(extractRoute(files[Constants.DESTINATION_LOCAION]));

		if(startLocation.isDirectory() && destinaionLocation.isDirectory()) { // 경로 맞고 파일 이동 성공했으면
			if(startFile.renameTo(destinaionFile)){
				print.printSentence("파일을 이동하였습니다.");
			}
			else {
				print.printSentence("지정된 파일을 찾을 수 없습니다.");
			}
		}
		else {
			print.printSentence("지정된 경로를 찾을 수 없습니다.");
		}		
		
		//System.out.println(startFile);
		//System.out.println(destinaionFile);
		//System.out.println(startLocation);
		//System.out.println(destinaionLocation);
	}
			
	

		
	
	
	
	private String[] sliceSentence(String inputCommand) {
		String slicedSentence[] = inputCommand.split(" ");
			return slicedSentence;
	}
	
	
	private int blankCount(String command, char string) { 
		
		int blankCount = Constants.RESET;         
		
		for (int index = Constants.START; index < command.length(); index++) {
			if (command.charAt(index) == string) { 
				blankCount++;            
				}        
			}        
		
		return blankCount;   
	}
	
	private int checkBlankAndSlash(String command, String blank) {
		int blankAndSlashCount = Constants.RESET;
		for (int index = Constants.RESET; index < command.length(); index++) {
            if (command.substring(index).startsWith(blank)) {
            	blankAndSlashCount++;
            }
        }
		
		
		return blankAndSlashCount;
	}
	
	public String extractFile(String sentence) {
		Pattern pattern = Pattern.compile("[^\\\\/\\n]+$");
		
		Matcher matcher = pattern.matcher(sentence);
		while (matcher.find()) {
			return matcher.group();
		}
		return "";
	}
	
	public String extractRoute(String sentence) {
		Pattern pattern = Pattern.compile(".+\\\\(?=.+)");
		
		Matcher matcher = pattern.matcher(sentence);
		while (matcher.find()) {
			return matcher.group();
		}
		return "";
	}
}
