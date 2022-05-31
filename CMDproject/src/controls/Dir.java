package controls;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.text.SimpleDateFormat;
import java.util.Date;

import models.RouteLocation;
import utility.Constants;
import utility.dataProcessing;
import views.PrintLocation;

public class Dir {
	private RouteLocation location;
	private PrintLocation print;
	private dataProcessing data;
	
	public Dir(RouteLocation location, PrintLocation print, dataProcessing data) {
		this.location = location;
		this.print = print;
		this.data = data;
	}
	
	public void CheckcurrentLocationOrDesignateDir(String inputDirectory) {
		
			getCmdNumber(); // 일련번호 출력 
	
			
			if(inputDirectory.contains("dir ")) {// dir 후 위치지정				
				location.setTemporaryStorage(location.getCurrentLocation()); // 임시저장소 dir + 위치 입력 전 위치값 저장
				printDesignateLocationDir(inputDirectory);
			}
			
			else if(inputDirectory.equals("dir")) {
				printCurrentLocationDir(!Constants.IS_DESIGNATE_LOCATION_DIR); // 현재위치 dir 출력
			}	
	}
	
	private void printDesignateLocationDir(String inputDirectory) {// 위치 지정 후 dir 출력
		
	    String cdAndCommand[] = inputDirectory.split(" ");                 
		File directory = new File("\\" + cdAndCommand[Constants.COMMAND]);
		File currentLocation = new File(location.getCurrentLocation() + directory);
		 
		 if(currentLocation.isDirectory()) {
			 location.setCurrentLocation(location.getCurrentLocation() + directory);  // 현재 위치 저장 
			 printCurrentLocationDir(Constants.IS_DESIGNATE_LOCATION_DIR);
		} 
		 
		 else { // dir askldasdlkj 이상한 값 입력했을 때
			 print.printSentence("파일을 찾을 수 없습니다.\n\n");  
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
		}
	}
	
	private void printCurrentLocationDir(boolean judgment) { // 현재위치 dir 저장
		String storedLocation = location.getCurrentLocation();
		String dotDirectory = "";
		if(storedLocation.equals("")) storedLocation = "\\"; // 루트 폴더일 때 
		
		File currentLocation = new File(storedLocation);
		File[] directoryList = currentLocation.listFiles(); // 현재위치
	    SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd a HH:mm"); // 시간 
	    
		long directoryLength = Constants.RESET;	
		long fileLength = Constants.RESET;
		long directoryByte = Constants.RESET;
		long fileByte = Constants.RESET;
		
		dotDirectory = extractDotDirectory(storedLocation); // 디렉토리에서  . .. 폴더 추출 
		
	    File changeDotDirectory = new File(dotDirectory);
	    
	    for(int index=Constants.START; index < directoryList.length; index++) {
	    	
	    String attribute = "";
	    String size = "";
	    if(dotDirectory != "") {   	 	
	    	attribute = "<DIR>";
	    	directoryLength++; // 디렉토리 개수
	    	print.printDirDot(date, attribute, size, changeDotDirectory, ".");
	    	print.printDirDot(date, attribute, size, changeDotDirectory, "..");
	    	dotDirectory = "";
	    }
	    
	    if(directoryList[index].isDirectory() && !directoryList[index].isHidden()){ // 디렉토리이면  DIR 저장 
	        attribute = "<DIR>";	 	   
	        directoryLength++; // 디렉토리 개수 
	    	print.printDir(date, attribute, size, directoryList[index]); // dir 출력
	       }
	    
	    else if(!directoryList[index].isDirectory() && !directoryList[index].isHidden()) {
	    	
	    	if(directoryList[index].isFile()) {
		    	fileLength++; // 파일개수 
		    	fileByte += directoryList[index].length(); // 파일 용량 
	    	}
	    	if(directoryList[index].length() != Constants.RESET) {
	    		size = directoryList[index].length() + ""; // 디렉토리 아닐 때 0 이면 ""로 치환
	    	}
	    	print.printDir(date, attribute, size, directoryList[index]); // dir 출력
	        
	    }

	   }
	    directoryByte = currentLocation.getUsableSpace(); // 남은 바이트
	    print.printFileAndDirectoryData(fileLength, directoryLength, data.setComma(Long.toString(fileByte)), data.setComma(Long.toString(directoryByte)));
	     
	    
	    if(judgment == Constants.IS_DESIGNATE_LOCATION_DIR) location.setCurrentLocation(location.getTemporaryStorage());
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
	}
	
	
	
	private String extractDotDirectory(String currentLocation) {
		int slashCount=Constants.RESET;
		String beforeCommand[] = currentLocation.split("\\\\"); // \기준으로 문자열 스플릿
		String dotFile = ""; 
					
		slashCount = (data.countSlash(currentLocation, '\\')); // \ 갯수세기
		currentLocation = ""; // 초기화
		
		for(int index=Constants.FIRST_LOCATION; index<slashCount; index++) { // 현재 기준 전 위치까지 자르기
			currentLocation = (currentLocation + "\\" +  beforeCommand[index]);
		}
		
		if(location.getCurrentLocation().equals("")) return dotFile; // 현재위치가 root 일 때
		if(slashCount == Constants.BLANK_LOCATION) currentLocation = ("\\"); // 현재 위치가 root 바로 다음 일 때
		
		File beforeDirectory = new File(currentLocation);		
		File[] directoryList = beforeDirectory.listFiles();
		 
		
		 for(int index=Constants.START; index < directoryList.length; index++) {
		    		    
		    if(directoryList[index].isDirectory() && !directoryList[index].isHidden()){ // 디렉토리이면  DIR 저장  	   
		    	
		        if(data.capitalizeFirstLetter(directoryList[index].getName().toString())
		        	.equals(data.capitalizeFirstLetter(beforeCommand[slashCount]))) { // User 앞글자가 대문자인데 디렉토리명과 같으면
		        	dotFile = directoryList[index].toString(); // cmd에서 .에 해당하는 디렉토리 저장
		        }
		 }
		 
	 }
		 
	return dotFile;
}
	private void getCmdNumber() {
		try {
			String line;
			InputStream cmdNumber;
			cmdNumber = Runtime.getRuntime().exec("cmd /c " + "dir").getInputStream();
			BufferedReader bufferReader = new BufferedReader(new InputStreamReader(cmdNumber, "MS949"));
			for(int index=Constants.START;index<Constants.CMD_NUMBER;index++) {
				line = bufferReader.readLine();
				System.out.println(line);
			}
			System.out.println();
			bufferReader.close();
			cmdNumber.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}