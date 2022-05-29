package controls;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

import models.RouteLocation;
import utility.Constants;
import utility.dataProcessing;
import views.PrintLocation;

public class Copy {

	private RouteLocation location;
	private PrintLocation print;
	private dataProcessing data;
		
	public Copy(RouteLocation location, PrintLocation print, dataProcessing data) {
		this.location = location;
		this.print = print;
		this.data = data;
	}
	
	//StandardCopyOption.REPLACE_EXISTING �����
	
	public void copyController(String inputCommand) {
		if(inputCommand.contains("copy ") && !inputCommand.contains("\\")) copyFileCurrentLocationToCurrentLocation(inputCommand);  //copy a.txt b.txt 1�� 
		else if(data.checkBlankAndSlash(inputCommand, " \\") == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {// copy\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt 4�� 
			copyFileNewLocationToNewLocation(inputCommand);
		}
		else if(data.blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) { // copy a.txt users\\user\onedrive\desktop\b.txt 2�� 
			copyFileCurrentLocationToNewLocation(inputCommand);
		}		
		else {// copy\\users\\user\onedrive\desktop\a.txt b.txt 3��, // copy\\users\\user\desktop\a.txt 5��
			copyFileNewLocationToCurrentLocation(inputCommand);
		}
		
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	private void copyFileCurrentLocationToCurrentLocation(String inputCommand) { // 1��
		String slicedSentence[];
		slicedSentence = data.sliceSentence(inputCommand);
		
		File oldfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);
			
		try {
			Files.copy(oldfile.toPath(), newfile.toPath());
			print.printSentence("     1�� ������ ����Ǿ����ϴ�.\n");
		} 
		catch(java.nio.file.NoSuchFileException e) {
			print.printSentence("������ ������ ã�� �� �����ϴ�.\n");
		}
		catch(java.nio.file.FileAlreadyExistsException e) {
			print.printSentence(slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE] + "��(��) ����ðڽ��ϱ�? (Yes/No/All):");
			if(data.is_inputYesOrNo()) {
				print.printSentence("     1�� ������ ����Ǿ����ϴ�.\n");
			}
			else {
				print.printSentence("     0�� ������ ����Ǿ����ϴ�.\n");
			}
		}
		catch (IOException e) {
			e.printStackTrace();
		}

		/*
		if(oldfile.renameTo(newfile)){
			print.printMoveFileSucessOrFail("1�� ������ �̵��߽��ϴ�.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("������ ������ ã�� �� �����ϴ�.", !Constants.IS_SUCESS);
		}
		*/
	}
	
	
	private void copyFileCurrentLocationToNewLocation(String inputCommand) { // ���� ��ġ���� ����ũž�� b.txt���� ���� �̵� 2��
		String file =  data.extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt ����
		String route = data.extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ ����
		String fileAndLocation[];

		fileAndLocation = data.sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, ��� ����
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // ���丮 ��ġ
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // ������ġ + ����
		File newFile = new File(newLocation + "\\" + file); // ������ġ + ����
		
		
		/*
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
	*/
	}
	
	private void copyFileNewLocationToNewLocation(String inputCommand) { // 4��
		String files[] = data.sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinationFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(data.extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(data.extractRoute(files[Constants.DESTINATION_LOCAION]));

		checkFileAndDirectoryAfterPrint(startLocation, destinaionLocation, startFile, destinationFile);	
		
	}
	
			
	private void copyFileNewLocationToCurrentLocation(String inputCommand) { // 3, 5�� 
		inputCommand = inputCommand.replace("move", "");
		String files[];
		String file = data.extractFile(inputCommand);
		File newLocation = new File(data.extractRoute(inputCommand)); // move\\users\\user\onedrive\desktop
		File currentLocaion = new File(location.getCurrentLocation()); // ������ġ

				
		if(file.contains(" ")) { // move\\users\\user\onedrive\desktop\a.txt b.txt ���
			files = data.sliceSentence(file);	
			File startFile = new File(newLocation + "\\" + files[Constants.OLD_FILE]);
			File destinationFile = new File(location.getCurrentLocation() + "\\" + files[Constants.NEW_FILE]);
			checkFileAndDirectoryAfterPrint(currentLocaion, newLocation, startFile, destinationFile);					
		}
		
		else {
			File startFile = new File(newLocation + "\\" + file);
			File destinationFile = new File(location.getCurrentLocation() + "\\" + file);
			checkFileAndDirectoryAfterPrint(currentLocaion, newLocation, startFile, destinationFile);	
		}

	}


	private void checkFileAndDirectoryAfterPrint(File startLocation, File destinaionLocation, File startFile, File destinationFile) {
		
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
