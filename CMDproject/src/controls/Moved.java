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
		//move a.txt b.txt 1�� 
		if(inputCommand.contains("move ") && !inputCommand.contains("\\")) MoveFileCurrentLocationToCurrentLocation(inputCommand);  //move a.txt b.txt
		// move\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt 4�� 
		else if(checkBlankAndSlash(inputCommand, " \\") == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {
			MoveFileNewLocationToNewLocation(inputCommand);
			System.out.println("44444");
		}
		// move a.txt users\\user\onedrive\desktop\b.txt 2�� 
		else if(blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {
			MoveFileCurrentLocationToDestinationLocation(inputCommand);
			System.out.println("22222222");
		}		
		// move\\users\\user\onedrive\desktop\a.txt b.txt 3��
		// move\\users\\user\desktop\a.txt 5��
		else System.out.println("55555");
		
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	private void MoveFileCurrentLocationToCurrentLocation(String inputCommand) {
		String slicedSentence[];
		slicedSentence = sliceSentence(inputCommand);
		
		File oldfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

		if(oldfile.renameTo(newfile)){
			print.printMoveFileSucessOrFail("1�� ������ �̵��߽��ϴ�.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("������ ������ ã�� �� �����ϴ�.", !Constants.IS_SUCESS);
		}
	}
	
	
	private void MoveFileCurrentLocationToDestinationLocation(String inputCommand) { // ���� ��ġ���� ����ũž�� b.txt���� ���� �̵�
		String file =  extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt ����
		String route = extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ ����
		String fileAndLocation[];

		fileAndLocation = sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, ��� ����
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // ���丮 ��ġ
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // ������ġ + ����
		File newFile = new File(newLocation + "\\" + file); // ������ġ + ����
		
		if(newLocation.isDirectory() && oldFile.renameTo(newFile)) { // ��� �°� ���� �̵� ����������
			print.printSentence("������ �̵��Ͽ����ϴ�.");
		}
		else {
			print.printSentence("������ ��θ� ã�� �� �����ϴ�.\r\n"
							+ "     0�� ������ �̵��߽��ϴ�.");
		}		
	}
	
	
	private void MoveFileNewLocationToNewLocation(String inputCommand) {
		String files[] = sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinaionFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(extractRoute(files[Constants.DESTINATION_LOCAION]));

		if(startLocation.isDirectory() && destinaionLocation.isDirectory()) { // ��� �°� ���� �̵� ����������
			if(startFile.renameTo(destinaionFile)){
				print.printSentence("������ �̵��Ͽ����ϴ�.");
			}
			else {
				print.printSentence("������ ������ ã�� �� �����ϴ�.");
			}
		}
		else {
			print.printSentence("������ ��θ� ã�� �� �����ϴ�.");
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
