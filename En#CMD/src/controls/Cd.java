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
		//File f = new File("c:\\Users\\user\\OneDrive\\Desktop");
		 
		if(inputDirectory.contains("cd")) {
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
		 
		 //System.out.println("directory=" + directory);
		 //System.out.println(location.getCurrentLocation());
		 return currentLocation.isDirectory(); // true면 존재, false면 존재 x
		}
		
		location.setErrorMessage("'"+inputDirectory+"'" + "은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는 배치 파일이 아닙니다."); // cd를 쓰지 않으면 
		return false;
	}
}
