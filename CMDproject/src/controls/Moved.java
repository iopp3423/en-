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
			print.printSentence("명령 구문이 올바르지 않습니다.\n\n");
		}
		else if(inputCommand.contains("move ") && !inputCommand.contains("\\")) {
			moveFileCurrentLocationToCurrentLocation(inputCommand);  //move a.txt b.txt 1번 
		}
		else if(data.checkBlankAndSlash(inputCommand, " \\") == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {// move\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt 4번 
			moveFileNewLocationToNewLocation(inputCommand);
		}
		else if(inputCommand.contains("move \\")){// move\\users\\user\onedrive\desktop\a.txt b.txt 3번, // move\\users\\user\desktop\a.txt 5번
			moveFileNewLocationToCurrentLocation(inputCommand);
		}
		else if(data.blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) { // move a.txt users\\user\onedrive\desktop\b.txt 2번 
			moveFileCurrentLocationToNewLocation(inputCommand);
		}		
		
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	private void moveFileCurrentLocationToCurrentLocation(String inputCommand) { // 1번
		String slicedSentence[];
		slicedSentence = data.sliceSentence(inputCommand);
		
		File oldFile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newFile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

		if(MoveoverapFile(oldFile, newFile) == Constants.IS_ERROR) {
			
		}
		else if(oldFile.renameTo(newFile)){
			print.printMoveFileSucessOrFail("1개 파일을 이동했습니다.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("지정된 파일을 찾을 수 없습니다.", !Constants.IS_SUCESS);
		}
	}
	
	
	private void moveFileCurrentLocationToNewLocation(String inputCommand) { // 현재 위치에서 데스크탑에 b.txt으로 파일 이동 2번
		String file =  data.extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt 추출
		String route = data.extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ 추출
		String fileAndLocation[];

		fileAndLocation = data.sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, 경로 저장
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // 디렉토리 위치
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // 현재위치 + 파일
		File newFile = new File(newLocation + "\\" + file); // 지정위치 + 파일
		
		if(MoveoverapFile(oldFile, newFile) == Constants.IS_ERROR) {		
		}

		else if(newLocation.isDirectory()){	
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
	
	private void moveFileNewLocationToNewLocation(String inputCommand) { // 4번
		String files[] = data.sliceSentence(inputCommand);

		File startFile = new File(files[Constants.START_LOCAION]);
		File destinationFile = new File(files[Constants.DESTINATION_LOCAION]);		
		File startLocation = new File(data.extractRoute(files[Constants.START_LOCAION]));
		File destinaionLocation = new File(data.extractRoute(files[Constants.DESTINATION_LOCAION]));

		if(MoveoverapFile(startFile, destinationFile) == Constants.IS_ERROR) {		
		}
		
		else checkFileAndDirectoryAfterPrint(startLocation, destinaionLocation, startFile, destinationFile);	
		
	}
	
			
	private void moveFileNewLocationToCurrentLocation(String inputCommand) { // 3, 5번 
		inputCommand = inputCommand.replace("move ", "");
		String files[];
		String file = data.extractFile(inputCommand);
		File newLocation = new File(data.extractRoute(inputCommand)); // move\\users\\user\onedrive\desktop
		File currentLocaion = new File(location.getCurrentLocation()); // 현재위치

				
		if(file.contains(" ")) { // move\\users\\user\onedrive\desktop\a.txt b.txt 경우
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
	
	private boolean MoveoverapFile(File startLocation, File destinationLocation) {
		boolean is_overapFile = true;
		
		if(startLocation.isFile() && destinationLocation.isFile()) { // 이미 파일이 있을 때 
			try {
				Files.copy(startLocation.toPath(), destinationLocation.toPath());
				print.printSentence("     1개 파일이 복사되었습니다.\n");
			} 

			catch(java.nio.file.FileAlreadyExistsException e) {
				is_overapFile = false;

				print.printSentence(destinationLocation + "을(를) 덮어쓰시겠습니까? (Yes/No/All):");	
				
				if(data.is_inputYesOrNo()) {
					try {
						Files.copy(startLocation.toPath(), destinationLocation.toPath(),StandardCopyOption.REPLACE_EXISTING);
						startLocation.delete(); // 파일 복사 후 삭제
					} catch (IOException e1) {
						e1.printStackTrace();
					}
					print.printSentence("     1개 파일을 이동했습니다.\n");
				}
				else {
					print.printSentence("     0개 파일을 이동했습니다.\n");
				}
			}
			catch (IOException e) {
				e.printStackTrace();
			}	     
		} 	
		
		return is_overapFile;
	}
	
	
}
