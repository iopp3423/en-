package controls;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
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

	public void controlMove(String inputCommand) {
		if(inputCommand.equals("move")) {
			print.printSentence("��� ������ �ùٸ��� �ʽ��ϴ�.\n\n");
		}
		else if(inputCommand.contains("move ") && !inputCommand.contains("\\")) {
			moveFileCurrentLocationToCurrentLocation(inputCommand);  //move a.txt b.txt 1�� 
		}
		else if(data.checkBlankAndSlash(inputCommand, " \\") == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {// move\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt 4�� 
			moveFileNewLocationToNewLocation(inputCommand);
		}
		else if(inputCommand.contains("move \\")){// move\\users\\user\onedrive\desktop\a.txt b.txt 3��, // move\\users\\user\desktop\a.txt 5��
			moveFileNewLocationToCurrentLocation(inputCommand);
		}
		else if(data.blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) { // move a.txt users\\user\onedrive\desktop\b.txt 2�� 
			moveFileCurrentLocationToNewLocation(inputCommand);
		}		
		
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	private void moveFileCurrentLocationToCurrentLocation(String inputCommand) { // 1��
		String slicedSentence[];
		slicedSentence = data.sliceSentence(inputCommand);
		
		File oldFile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newFile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

		if(MoveoverapFile(oldFile, newFile) == Constants.IS_ERROR) {
			
		}
		else if(oldFile.renameTo(newFile)){
			print.printMoveFileSucessOrFail("1�� ������ �̵��߽��ϴ�.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("������ ������ ã�� �� �����ϴ�.", !Constants.IS_SUCESS);
		}
	}
	
	
	private void moveFileCurrentLocationToNewLocation(String inputCommand) { // ���� ��ġ���� ����ũž�� b.txt���� ���� �̵� 2��
		String file =  data.extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt ����
		String route = data.extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ ����
		String fileAndLocation[];

		fileAndLocation = data.sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, ��� ����
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // ���丮 ��ġ
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // ������ġ + ����
		File newFile = new File(newLocation + "\\" + file); // ������ġ + ����
		
		if(MoveoverapFile(oldFile, newFile) == Constants.IS_ERROR) {		
		}

		else if(newLocation.isDirectory()){	
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
	
	private void moveFileNewLocationToNewLocation(String inputCommand) { // 4��
		String files[] = data.sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinationFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(data.extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(data.extractRoute(files[Constants.DESTINATION_LOCAION]));

		if(MoveoverapFile(startFile, destinationFile) == Constants.IS_ERROR) {		
		}
		
		else checkFileAndDirectoryAfterPrint(startLocation, destinaionLocation, startFile, destinationFile);	
		
	}
	
			
	private void moveFileNewLocationToCurrentLocation(String inputCommand) { // 3, 5�� 
		inputCommand = inputCommand.replace("move ", "");
		String files[];
		String file = data.extractFile(inputCommand);
		File newLocation = new File(data.extractRoute(inputCommand)); // move\\users\\user\onedrive\desktop
		File currentLocaion = new File(location.getCurrentLocation()); // ������ġ

				
		if(file.contains(" ")) { // move\\users\\user\onedrive\desktop\a.txt b.txt ���
			files = data.sliceSentence(file);	
			File startFile = new File(newLocation + "\\" + files[Constants.OLD_FILE]);
			File destinationFile = new File(location.getCurrentLocation() + "\\" + files[Constants.NEW_FILE]);
			
			if(MoveoverapFile(startFile, destinationFile) == Constants.IS_ERROR) {		
			}
			else checkFileAndDirectoryAfterPrint(currentLocaion, newLocation, startFile, destinationFile);					
		}
		
		else {
			File startFile = new File(newLocation + "\\" + file);
			File destinationFile = new File(location.getCurrentLocation() + "\\" + file);
			
			if(MoveoverapFile(startFile, destinationFile) == Constants.IS_ERROR) {		
			}
			else checkFileAndDirectoryAfterPrint(currentLocaion, newLocation, startFile, destinationFile);	
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
	
	private boolean MoveoverapFile(File startLocation, File destinationLocation) {
		boolean is_overapFile = true;
		
		if(startLocation.isFile() && destinationLocation.isFile()) { // �̹� ������ ���� �� 
			try {
				Files.copy(startLocation.toPath(), destinationLocation.toPath());
				print.printSentence("     1�� ������ ����Ǿ����ϴ�.\n");
			} 

			catch(java.nio.file.FileAlreadyExistsException e) {
				is_overapFile = false;

				print.printSentence(destinationLocation + "��(��) ����ðڽ��ϱ�? (Yes/No/All):");	
				
				if(data.is_inputYesOrNo()) {
					try {
						Files.copy(startLocation.toPath(), destinationLocation.toPath(),StandardCopyOption.REPLACE_EXISTING);
						startLocation.delete(); // ���� ���� �� ����
					} catch (IOException e1) {
						e1.printStackTrace();
					}
					print.printSentence("     1�� ������ �̵��߽��ϴ�.\n");
				}
				else {
					print.printSentence("     0�� ������ �̵��߽��ϴ�.\n");
				}
			}
			catch (IOException e) {
				e.printStackTrace();
			}	     
		} 	
		
		return is_overapFile;
	}
	
	
}
