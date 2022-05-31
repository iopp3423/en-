package controls;

import java.io.File;

import models.RouteLocation;
import utility.Constants;
import utility.dataProcessing;
import views.PrintLocation;


public class Cd {
	private RouteLocation location;
	private PrintLocation print;
	private dataProcessing data;
	
	public Cd(RouteLocation location, PrintLocation print, dataProcessing data) {
		this.location = location;
		this.print = print;
		this.data = data;
	}

	
	
	public void CheckLocationOrError(String inputDirectory) {
		
		if(CheckDirectoryAndStoreLocation(inputDirectory)) { // 경로가 맞으면 
			if(location.getCurrentLocation().equals("")) { // root폴더이면 
				print.printCurrentLocation("C:\\" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);
			}
			else{
				print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
			}
		 } 
		
		 else { // 경로가 맞지 않으면
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), Constants.IS_ERROR);  // 지정된 경로를 찾을 수 없습니다 출력 
		    }
	}
	
	public boolean CheckDirectoryAndStoreLocation(String inputDirectory) {
		if(inputDirectory.equals("cd"))return true;
		else if(inputDirectory.equals("cd\\")) { // 처음으로 이동
			location.setCurrentLocation("");
			return true;
		}	
		else if(inputDirectory.equals("cd..")) return MoveOneStopUp();	
		else if(inputDirectory.equals("cd..\\..")) return MoveTwoStepUp();
		else if(inputDirectory.contains("cd ")) return actCd(inputDirectory);// cd명령
		else {
			location.setErrorMessage("'"+inputDirectory+"'" + "은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는 배치 파일이 아닙니다."); // cd를 쓰지 않으면 
			return false;
		}
		
	}
	
	private boolean MoveOneStopUp() {
		int slashCount=Constants.RESET;
		String beforeCommand[] = location.getCurrentLocation().split("\\\\"); // \기준으로 문자열 스플릿
					
		slashCount = (data.countSlash(location.getCurrentLocation(), '\\')); // \ 갯수세기
		location.setCurrentLocation(""); // 초기화
		
		for(int index=Constants.FIRST_LOCATION; index<slashCount; index++) {
			location.setCurrentLocation(location.getCurrentLocation() + "\\" +  beforeCommand[index]);
		}
		
		return true;
	}
	
	private boolean MoveTwoStepUp() {	
		int slashCount=Constants.RESET;
		String beforeCommand[] = location.getCurrentLocation().split("\\\\"); // \기준으로 문자열 스플릿
					
		slashCount = (data.countSlash(location.getCurrentLocation(), '\\')); // \ 갯수세기
		location.setCurrentLocation(""); // 초기화
		
		for(int index=Constants.FIRST_LOCATION; index<slashCount-Constants.TWO_STEP_UP; index++) {
			location.setCurrentLocation(location.getCurrentLocation() +"\\" +  beforeCommand[index]);
		}
		return true;
	}

	
	private boolean actCd(String inputDirectory) {
		
		String cdAndCommand[] = inputDirectory.split(" ");
		File directory = new File("\\" + cdAndCommand[Constants.COMMAND]);
		File currentLocation = new File(location.getCurrentLocation() + directory);

		if(inputDirectory.contains("cd \\")){
			location.setErrorMessage("지정된 경로를 찾을 수 없습니다.\n");   
			return Constants.IS_ERROR;
		}
		else if(currentLocation.isDirectory()) {
			 location.setCurrentLocation(location.getCurrentLocation() + directory);  // 현재 위치 저장 
		    } 
		 else {
			 location.setErrorMessage("지정된 경로를 찾을 수 없습니다.");     
		    }
		 
		 return currentLocation.isDirectory(); // true면 존재, false면 존재 x
	}
	
}
