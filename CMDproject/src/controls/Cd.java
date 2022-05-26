package controls;

import java.io.File;

import models.RouteLocation;
import utility.Constants;
import views.PrintLocation;


public class Cd {
	private RouteLocation location;
	private PrintLocation print;
	
	public Cd(RouteLocation location, PrintLocation print) {
		this.location = location;
		this.print = print;
	}

	
	
	public void CheckLocationOrError(String inputDirectory) {
		
		if(CheckDirectoryAndStoreLocation(inputDirectory)) { // 경로가 맞으면 
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
		    } 
		 else { // 경로가 맞지 않으면
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), Constants.IS_ERROR);  // 지정된 경로를 찾을 수 없습니다 출력 
		    }
	}
	
	public boolean CheckDirectoryAndStoreLocation(String inputDirectory) {
		if(inputDirectory.equals("cd")) { // 기존 주소 유지
			return true;
		}
		else if(inputDirectory.equals("cd\\")) { // 처음으로 이동
			location.setCurrentLocation("");
			return true;
		}
		
		else if(inputDirectory.equals("cd..")) { // 1단계 위로 이동
			int slashCount=Constants.RESET;
			String beforeCommand[] = location.getCurrentLocation().split("\\\\"); // \기준으로 문자열 스플릿
						
			slashCount = (countChar(location.getCurrentLocation(), '\\')); // \ 갯수세기
			location.setCurrentLocation(""); // 초기화
			
			for(int index=Constants.FIRST_LOCATION; index<slashCount; index++) {
				location.setCurrentLocation(location.getCurrentLocation() +"\\" +  beforeCommand[index]);
			}
			
			return true;
		}
		
		else if(inputDirectory.equals("cd..\\..")) { // 2단계 위로 이동
			
			int slashCount=Constants.RESET;
			String beforeCommand[] = location.getCurrentLocation().split("\\\\"); // \기준으로 문자열 스플릿
						
			slashCount = (countChar(location.getCurrentLocation(), '\\')); // \ 갯수세기
			location.setCurrentLocation(""); // 초기화
			
			for(int index=Constants.FIRST_LOCATION; index<slashCount-Constants.TWO_STEP_UP; index++) {
				location.setCurrentLocation(location.getCurrentLocation() +"\\" +  beforeCommand[index]);
			}
			return true;
		}
		
		
		else if(inputDirectory.contains("cd")) {// cd ~~ 명령 
        String cdAndCommand[] =inputDirectory.split(" ");                 
		File directory = new File("\\" + cdAndCommand[Constants.COMMAND]);
		File currentLocation = new File(location.getCurrentLocation() + directory);
		
		 if(currentLocation.isDirectory()) {
			 location.setCurrentLocation(location.getCurrentLocation() + directory);  // 현재 위치 저장 
			 System.out.println("디렉토리 위치 맞음");
		    } 
		 else {
			 location.setErrorMessage("지정된 경로를 찾을 수 없습니다.");            
		    }
		 return currentLocation.isDirectory(); // true면 존재, false면 존재 x
		}
		
		else {
			location.setErrorMessage("'"+inputDirectory+"'" + "은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는 배치 파일이 아닙니다."); // cd를 쓰지 않으면 
			return false;
		}
		
	}



	public int countChar(String command, char slash) { // \ 개수세기
		
		int slashCount = Constants.RESET;         
		
		for (int index = Constants.START; index < command.length(); index++) {
			if (command.charAt(index) == slash) { 
				slashCount++;            
				}        
			}        
		
		return slashCount;   
	}	
}


//System.out.println("directory=" + directory);
//System.out.println(location.getCurrentLocation());