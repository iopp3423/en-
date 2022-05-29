package controls;

import java.io.File;
import java.io.IOException;
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
			 print.printSentence(" C 드라이브의 볼륨에는 이름이 없습니다.\n 볼륨 일련 번호 : BAF3-12D7\n\n");
			 print.printSentence("C:" + location.getCurrentLocation() + " 디렉터리\n\n");
			 print.printSentence("파일을 찾을 수 없습니다.\n\n");  
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
		}
	}
	
	private void printCurrentLocationDir(boolean judgment) { // 현재위치 dir 저장
		String storedLocation = location.getCurrentLocation();
		if(storedLocation.equals("")) storedLocation = "\\"; // 루트 폴더일 때 
		
		File currentLocation = new File(storedLocation);
		long directoryLength = Constants.RESET;	
		long fileLength = Constants.RESET;
		long directoryByte = Constants.RESET;
		long fileByte = Constants.RESET;
		
	    File[] dirList = currentLocation.listFiles(); // 현재위치
	    SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd a HH:mm"); // 시간 
	    
	    
	    for(int index=Constants.START; index < dirList.length; index++) {
	    	
	    String attribute = "";
	    String size = "";
	    
	    if(dirList[index].isDirectory() && !dirList[index].isHidden()){ // 디렉토리이면  DIR 저장 
	        attribute = "<DIR>";	 	   
	        directoryLength++; // 디렉토리 개수 
	    	print.printDir(date, attribute, size, dirList[index]); // dir 출력
	       }
	    
	    else if(!dirList[index].isDirectory() && !dirList[index].isHidden()) {
	    	
	    	if(dirList[index].isFile()) {
		    	fileLength++; // 파일개수 
		    	fileByte += dirList[index].length(); // 파일 용량 
	    	}
	    	if(dirList[index].length() != Constants.RESET) {
	    		size = dirList[index].length() + ""; // 디렉토리 아닐 때 0 이면 ""로 치환
	    	}
	    	print.printDir(date, attribute, size, dirList[index]); // dir 출력
	        
	    }

	   }
	    directoryByte = currentLocation.getUsableSpace();
	    print.printFileAndDirectoryData(fileLength, directoryLength, data.setComma(Long.toString(fileByte)), data.setComma(Long.toString(directoryByte)));
	     
	    
	    if(judgment == Constants.IS_DESIGNATE_LOCATION_DIR) location.setCurrentLocation(location.getTemporaryStorage());
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
	}
}