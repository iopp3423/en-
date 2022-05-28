package controls;

import java.io.File;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import models.RouteLocation;
import utility.Constants;
import utility.dataProcessing;
import views.PrintLocation;

public class Moved {
	private RouteLocation location;
	private PrintLocation print;
	private dataProcessing data;
	
	public Moved(RouteLocation location, PrintLocation print, dataProcessing data) {
		this.location = location;
		this.print = print;
		this.data = data;
	}

	public void moveController(String inputCommand) {
		if(inputCommand.contains("move ") && !inputCommand.contains("\\")) MoveFileCurrentLocationToCurrentLocation(inputCommand);  //move a.txt b.txt 1번 
		else if(data.checkBlankAndSlash(inputCommand, " \\") == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {// move\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt 4번 
			MoveFileNewLocationToNewLocation(inputCommand);
		}
		else if(data.blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) { // move a.txt users\\user\onedrive\desktop\b.txt 2번 
			MoveFileCurrentLocationToNewLocation(inputCommand);
		}		
		else {// move\\users\\user\onedrive\desktop\a.txt b.txt 3번, // move\\users\\user\desktop\a.txt 5번
			MoveFileNewLocationToCurrentLocation(inputCommand);
		}
		
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	private void MoveFileCurrentLocationToCurrentLocation(String inputCommand) { // 1번
		String slicedSentence[];
		slicedSentence = data.sliceSentence(inputCommand);
		
		File oldfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

		if(oldfile.renameTo(newfile)){
			print.printMoveFileSucessOrFail("1개 파일을 이동했습니다.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("지정된 파일을 찾을 수 없습니다.", !Constants.IS_SUCESS);
		}
	}
	
	
	private void MoveFileCurrentLocationToNewLocation(String inputCommand) { // 현재 위치에서 데스크탑에 b.txt으로 파일 이동 2번
		String file =  data.extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt 추출
		String route = data.extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ 추출
		String fileAndLocation[];

		fileAndLocation = data.sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, 경로 저장
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // 디렉토리 위치
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // 현재위치 + 파일
		File newFile = new File(newLocation + "\\" + file); // 지정위치 + 파일
		
		if(newLocation.isDirectory()){	
		
			if(oldFile.renameTo(newFile)) { // 경로 맞고 파일 이동 성공했으면
			print.printSentence("1개 파일을 이동하였습니다.\n");
			}
			else {
				print.printSentence("지정된 파일을 찾을 수 없습니다.\n");// 경로에 파일이 업으면
			}
		}		
		else {
			print.printSentence("지정된 경로를 찾을 수 없습니다.\r\n"
							+ "     0개 파일을 이동했습니다.\n");
		}		
	
	}
	
	private void MoveFileNewLocationToNewLocation(String inputCommand) { // 4번
		String files[] = data.sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinationFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(data.extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(data.extractRoute(files[Constants.DESTINATION_LOCAION]));

		CheckFileAndDirectoryAfterPrint(startLocation, destinaionLocation, startFile, destinationFile);	
		
	}
	
			
	private void MoveFileNewLocationToCurrentLocation(String inputCommand) { // 3, 5번 
		inputCommand = inputCommand.replace("move", "");
		String files[];
		String file = data.extractFile(inputCommand);
		File newLocation = new File(data.extractRoute(inputCommand)); // move\\users\\user\onedrive\desktop
		File currentLocaion = new File(location.getCurrentLocation()); // 현재위치

				
		if(file.contains(" ")) { // move\\users\\user\onedrive\desktop\a.txt b.txt 경우
			files = data.sliceSentence(file);	
			File startFile = new File(newLocation + "\\" + files[Constants.OLD_FILE]);
			File destinationFile = new File(location.getCurrentLocation() + "\\" + files[Constants.NEW_FILE]);
			CheckFileAndDirectoryAfterPrint(currentLocaion, newLocation, startFile, destinationFile);					
		}
		
		else {
			File startFile = new File(newLocation + "\\" + file);
			File destinationFile = new File(location.getCurrentLocation() + "\\" + file);
			CheckFileAndDirectoryAfterPrint(currentLocaion, newLocation, startFile, destinationFile);	
		}

	}


	private void CheckFileAndDirectoryAfterPrint(File startLocation, File destinaionLocation, File startFile, File destinationFile) {
		
		if(startLocation.isDirectory() && destinaionLocation.isDirectory()) { // 경로 맞고 파일 이동 성공했으면
			
			if(startFile.renameTo(destinationFile)){
				print.printSentence("1개 파일을 이동하였습니다.\n");
			}
			else {
				print.printSentence("지정된 파일을 찾을 수 없습니다.\n");
			}
		}
		else {
			print.printSentence("지정된 경로를 찾을 수 없습니다.\n");
		}
	}
}
