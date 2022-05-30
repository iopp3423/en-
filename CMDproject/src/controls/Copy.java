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
	
	public void controlCopy(String inputCommand) {
		if(inputCommand.equals("copy")) {
			print.printSentence("��� ������ �ùٸ��� �ʽ��ϴ�.\n\n");
		}
		else if(inputCommand.contains("copy ") && !inputCommand.contains("\\")) {
			copyFileCurrentLocationToCurrentLocation(inputCommand);  //copy a.txt b.txt 1�� 
		}
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
		
		File oldFile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newFile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);
		File currentLocation = new File(location.getCurrentLocation());
		
		checkFileAndDirectoryAfterPrint(currentLocation, currentLocation, oldFile, newFile, slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

	}
	
	
	private void copyFileCurrentLocationToNewLocation(String inputCommand) { // ���� ��ġ���� ����ũž�� b.txt���� ���� �̵� 2��
		String file =  data.extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt ����
		String route = data.extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ ����
		String fileAndLocation[];

		fileAndLocation = data.sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, ��� ����
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // ���丮 ��ġ
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // ������ġ + ����
		File newFile = new File(newLocation + "\\" + file); // ������ġ + ����
		
		if(newLocation.isDirectory()) {
			try {
				Files.copy(oldFile.toPath(), newFile.toPath());
				print.printSentence("     1�� ������ ����Ǿ����ϴ�.\n");
			} 
			catch(java.nio.file.NoSuchFileException e) {
				print.printSentence("������ ������ ã�� �� �����ϴ�.\n");
			}
			catch(java.nio.file.FileAlreadyExistsException e) {
				print.printSentence(fileAndLocation[Constants.FILE] + "��(��) ����ðڽ��ϱ�? (Yes/No/All):");
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
		}
		else {
			print.printSentence("������ ��θ� ã�� �� �����ϴ�.\r\n"
					+ "     0�� ������ ����Ǿ����ϴ�.\n");
		}
	}
	
	private void copyFileNewLocationToNewLocation(String inputCommand) { // 4��
		String files[] = data.sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinationFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(data.extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(data.extractRoute(files[Constants.DESTINATION_LOCAION]));
		String oldFile = data.extractFile(files[Constants.START_LOCAION]);
		
		checkFileAndDirectoryAfterPrint(startLocation, destinaionLocation, startFile, destinationFile, oldFile);	
		
	}
	
			
	private void copyFileNewLocationToCurrentLocation(String inputCommand) { // 3, 5�� 
		inputCommand = inputCommand.replace("copy", "");
		String files[];
		String file = data.extractFile(inputCommand);
		File newLocation = new File(data.extractRoute(inputCommand)); // move\\users\\user\onedrive\desktop
		File currentLocation = new File(location.getCurrentLocation()); // ������ġ

				
		if(file.contains(" ")) { // move\\users\\user\onedrive\desktop\a.txt b.txt ���
			files = data.sliceSentence(file);	
			File startFile = new File(newLocation + "\\" + files[Constants.OLD_FILE]);
			File destinationFile = new File(location.getCurrentLocation() + "\\" + files[Constants.NEW_FILE]);

			checkFileAndDirectoryAfterPrint(currentLocation, newLocation, startFile, destinationFile, files[Constants.OLD_FILE]);					
		}
		
		else {
			File startFile = new File(newLocation + "\\" + file); // copy\\users\\user\onedrive\desktop\a.txt��� 
			File destinationFile = new File(location.getCurrentLocation() + "\\" + file);
			
			checkFileAndDirectoryAfterPrint(currentLocation, newLocation, startFile, destinationFile, file);	
		}

	}


	private void checkFileAndDirectoryAfterPrint(File startLocation, File destinaionLocation, File startFile, File destinationFile, String oldFile) {
				
		if(startLocation.isDirectory() && destinaionLocation.isDirectory()) {
			try {
				Files.copy(startFile.toPath(), destinationFile.toPath());
				print.printSentence("     1�� ������ ����Ǿ����ϴ�.\n");
			} 
			catch(java.nio.file.NoSuchFileException e) {
				print.printSentence("������ ������ ã�� �� �����ϴ�.\n");
			}
			catch(java.nio.file.FileAlreadyExistsException e) {
				print.printSentence(oldFile + "��(��) ����ðڽ��ϱ�? (Yes/No/All):");
				
				if(data.is_inputYesOrNo()) {
					try {
						Files.copy(startFile.toPath(), destinationFile.toPath(),StandardCopyOption.REPLACE_EXISTING);
					} catch (IOException e1) {
						e1.printStackTrace();
					}
					print.printSentence("     1�� ������ ����Ǿ����ϴ�.\n");
				}
				
				else {
					print.printSentence("     0�� ������ ����Ǿ����ϴ�.\n");
				}
			}
			catch (IOException e) {
				e.printStackTrace();
			}	
		}
		else {
			print.printSentence("������ ��θ� ã�� �� �����ϴ�.\n");
		}
	}
}
