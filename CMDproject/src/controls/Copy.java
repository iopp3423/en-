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
	
	//StandardCopyOption.REPLACE_EXISTING 덮어쓰기
	
	public void controlCopy(String inputCommand) {
		if(inputCommand.equals("copy")) {
			print.printSentence("명령 구문이 올바르지 않습니다.\n\n");
		}
		else if(inputCommand.contains("copy ") && !inputCommand.contains("\\")) {
			copyFileCurrentLocationToCurrentLocation(inputCommand);  //copy a.txt b.txt 1번 
		}
		else if(data.checkBlankAndSlash(inputCommand, " \\") == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {// copy\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt 4번 
			copyFileNewLocationToNewLocation(inputCommand);
		}
		else if(data.blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) { // copy a.txt users\\user\onedrive\desktop\b.txt 2번 
			copyFileCurrentLocationToNewLocation(inputCommand);
		}		
		else {// copy\\users\\user\onedrive\desktop\a.txt b.txt 3번, // copy\\users\\user\desktop\a.txt 5번
			copyFileNewLocationToCurrentLocation(inputCommand);
		}
		
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	private void copyFileCurrentLocationToCurrentLocation(String inputCommand) { // 1번
		String slicedSentence[];
		slicedSentence = data.sliceSentence(inputCommand);
		
		File oldFile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newFile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);
		File currentLocation = new File(location.getCurrentLocation());
		
		checkFileAndDirectoryAfterPrint(currentLocation, currentLocation, oldFile, newFile, slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

	}
	
	
	private void copyFileCurrentLocationToNewLocation(String inputCommand) { // 현재 위치에서 데스크탑에 b.txt으로 파일 이동 2번
		String file =  data.extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt 추출
		String route = data.extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ 추출
		String fileAndLocation[];

		fileAndLocation = data.sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, 경로 저장
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // 디렉토리 위치
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // 현재위치 + 파일
		File newFile = new File(newLocation + "\\" + file); // 지정위치 + 파일
		
		if(newLocation.isDirectory()) {
			try {
				Files.copy(oldFile.toPath(), newFile.toPath());
				print.printSentence("     1개 파일이 복사되었습니다.\n");
			} 
			catch(java.nio.file.NoSuchFileException e) {
				print.printSentence("지정된 파일을 찾을 수 없습니다.\n");
			}
			catch(java.nio.file.FileAlreadyExistsException e) {
				print.printSentence(fileAndLocation[Constants.FILE] + "을(를) 덮어쓰시겠습니까? (Yes/No/All):");
				if(data.is_inputYesOrNo()) {
					print.printSentence("     1개 파일이 복사되었습니다.\n");
				}
				else {
					print.printSentence("     0개 파일이 복사되었습니다.\n");
				}
			}
			catch (IOException e) {
				e.printStackTrace();
			}	
		}
		else {
			print.printSentence("지정된 경로를 찾을 수 없습니다.\r\n"
					+ "     0개 파일이 복사되었습니다.\n");
		}
	}
	
	private void copyFileNewLocationToNewLocation(String inputCommand) { // 4번
		String files[] = data.sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinationFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(data.extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(data.extractRoute(files[Constants.DESTINATION_LOCAION]));
		String oldFile = data.extractFile(files[Constants.START_LOCAION]);
		
		checkFileAndDirectoryAfterPrint(startLocation, destinaionLocation, startFile, destinationFile, oldFile);	
		
	}
	
			
	private void copyFileNewLocationToCurrentLocation(String inputCommand) { // 3, 5번 
		inputCommand = inputCommand.replace("copy", "");
		String files[];
		String file = data.extractFile(inputCommand);
		File newLocation = new File(data.extractRoute(inputCommand)); // move\\users\\user\onedrive\desktop
		File currentLocation = new File(location.getCurrentLocation()); // 현재위치

				
		if(file.contains(" ")) { // move\\users\\user\onedrive\desktop\a.txt b.txt 경우
			files = data.sliceSentence(file);	
			File startFile = new File(newLocation + "\\" + files[Constants.OLD_FILE]);
			File destinationFile = new File(location.getCurrentLocation() + "\\" + files[Constants.NEW_FILE]);

			checkFileAndDirectoryAfterPrint(currentLocation, newLocation, startFile, destinationFile, files[Constants.OLD_FILE]);					
		}
		
		else {
			File startFile = new File(newLocation + "\\" + file); // copy\\users\\user\onedrive\desktop\a.txt경우 
			File destinationFile = new File(location.getCurrentLocation() + "\\" + file);
			
			checkFileAndDirectoryAfterPrint(currentLocation, newLocation, startFile, destinationFile, file);	
		}

	}


	private void checkFileAndDirectoryAfterPrint(File startLocation, File destinaionLocation, File startFile, File destinationFile, String oldFile) {
				
		if(startLocation.isDirectory() && destinaionLocation.isDirectory()) {
			try {
				Files.copy(startFile.toPath(), destinationFile.toPath());
				print.printSentence("     1개 파일이 복사되었습니다.\n");
			} 
			catch(java.nio.file.NoSuchFileException e) {
				print.printSentence("지정된 파일을 찾을 수 없습니다.\n");
			}
			catch(java.nio.file.FileAlreadyExistsException e) {
				print.printSentence(oldFile + "을(를) 덮어쓰시겠습니까? (Yes/No/All):");
				
				if(data.is_inputYesOrNo()) {
					try {
						Files.copy(startFile.toPath(), destinationFile.toPath(),StandardCopyOption.REPLACE_EXISTING);
					} catch (IOException e1) {
						e1.printStackTrace();
					}
					print.printSentence("     1개 파일이 복사되었습니다.\n");
				}
				
				else {
					print.printSentence("     0개 파일이 복사되었습니다.\n");
				}
			}
			catch (IOException e) {
				e.printStackTrace();
			}	
		}
		else {
			print.printSentence("지정된 경로를 찾을 수 없습니다.\n");
		}
	}
}
