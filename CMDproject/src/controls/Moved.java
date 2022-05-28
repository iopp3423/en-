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
		if(inputCommand.contains("move ") && !inputCommand.contains("\\")) MoveFileCurrentLocationToCurrentLocation(inputCommand);  //move a.txt b.txt 1�� 
		else if(data.checkBlankAndSlash(inputCommand, " \\") == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {// move\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt 4�� 
			MoveFileNewLocationToNewLocation(inputCommand);
		}
		else if(data.blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) { // move a.txt users\\user\onedrive\desktop\b.txt 2�� 
			MoveFileCurrentLocationToNewLocation(inputCommand);
		}		
		else {// move\\users\\user\onedrive\desktop\a.txt b.txt 3��, // move\\users\\user\desktop\a.txt 5��
			MoveFileNewLocationToCurrentLocation(inputCommand);
		}
		
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	private void MoveFileCurrentLocationToCurrentLocation(String inputCommand) { // 1��
		String slicedSentence[];
		slicedSentence = data.sliceSentence(inputCommand);
		
		File oldfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

		if(oldfile.renameTo(newfile)){
			print.printMoveFileSucessOrFail("1�� ������ �̵��߽��ϴ�.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("������ ������ ã�� �� �����ϴ�.", !Constants.IS_SUCESS);
		}
	}
	
	
	private void MoveFileCurrentLocationToNewLocation(String inputCommand) { // ���� ��ġ���� ����ũž�� b.txt���� ���� �̵� 2��
		String file =  data.extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt ����
		String route = data.extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ ����
		String fileAndLocation[];

		fileAndLocation = data.sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, ��� ����
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // ���丮 ��ġ
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // ������ġ + ����
		File newFile = new File(newLocation + "\\" + file); // ������ġ + ����
		
		if(newLocation.isDirectory()){	
		
			if(oldFile.renameTo(newFile)) { // ��� �°� ���� �̵� ����������
			print.printSentence("1�� ������ �̵��Ͽ����ϴ�.\n");
			}
			else {
				print.printSentence("������ ������ ã�� �� �����ϴ�.\n");// ��ο� ������ ������
			}
		}		
		else {
			print.printSentence("������ ��θ� ã�� �� �����ϴ�.\r\n"
							+ "     0�� ������ �̵��߽��ϴ�.\n");
		}		
	
	}
	
	private void MoveFileNewLocationToNewLocation(String inputCommand) { // 4��
		String files[] = data.sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinationFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(data.extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(data.extractRoute(files[Constants.DESTINATION_LOCAION]));

		CheckFileAndDirectoryAfterPrint(startLocation, destinaionLocation, startFile, destinationFile);	
		
	}
	
			
	private void MoveFileNewLocationToCurrentLocation(String inputCommand) { // 3, 5�� 
		inputCommand = inputCommand.replace("move", "");
		String files[];
		String file = data.extractFile(inputCommand);
		File newLocation = new File(data.extractRoute(inputCommand)); // move\\users\\user\onedrive\desktop
		File currentLocaion = new File(location.getCurrentLocation()); // ������ġ

				
		if(file.contains(" ")) { // move\\users\\user\onedrive\desktop\a.txt b.txt ���
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
		
		if(startLocation.isDirectory() && destinaionLocation.isDirectory()) { // ��� �°� ���� �̵� ����������
			
			if(startFile.renameTo(destinationFile)){
				print.printSentence("1�� ������ �̵��Ͽ����ϴ�.\n");
			}
			else {
				print.printSentence("������ ������ ã�� �� �����ϴ�.\n");
			}
		}
		else {
			print.printSentence("������ ��θ� ã�� �� �����ϴ�.\n");
		}
	}
}
