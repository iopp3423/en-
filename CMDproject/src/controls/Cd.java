package controls;

import java.io.File;
import java.io.IOException;

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

	
	
	public void checkLocationOrError(String inputDirectory) {
		
		if(checkDirectoryAndStoreLocation(inputDirectory)) { // 경로가 맞으면 
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
	
	public boolean checkDirectoryAndStoreLocation(String inputDirectory) {
		
		if(inputDirectory.equals("cd")) {
			print.printSentence("\n"); 
			return true;
		}
		else if(inputDirectory.equals("cd\\")) { // 처음으로 이동
			location.setCurrentLocation("");
			return true;
		}
		else if(inputDirectory.contains("..")) return moveStepUP(inputDirectory);		
		else if(inputDirectory.contains("cd ")) return actCd(inputDirectory);// cd명령
		else{
			location.setErrorMessage("'"+inputDirectory+"'" + "은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는 배치 파일이 아닙니다."); // cd를 쓰지 않으면 
			return false;
		}
		
	}
	
	private boolean actCd(String inputDirectory) {
		
		String cdAndCommand[] = inputDirectory.split(" ");
		File directory = new File("\\" + cdAndCommand[Constants.COMMAND]);
		File currentLocation = new File(location.getCurrentLocation() + directory);
		File resetLocation = new File(cdAndCommand[Constants.COMMAND]);

		if(inputDirectory.contains("cd \\")){
			if(resetLocation.isDirectory()) {
				location.setCurrentLocation(resetLocation.toString());
				return !Constants.IS_ERROR;	
			}
			else {
				location.setErrorMessage("지정된 경로를 찾을 수 없습니다.\n");
				return Constants.IS_ERROR;
			}
		}
		else if(currentLocation.isDirectory()) {
			 location.setCurrentLocation(location.getCurrentLocation() + directory);  // 현재 위치 저장 
		    } 
		 else {
			 location.setErrorMessage("지정된 경로를 찾을 수 없습니다.");     
		    }
		 
		 return currentLocation.isDirectory(); // true면 존재, false면 존재 x
	}
	
	
	private boolean moveStepUP(String inputCommand) {
		
		String change = location.getCurrentLocation()+ "\\" + inputCommand;
	
		change = change.replace("cd", "");
		change = change.replace(" ", "");
		inputCommand = inputCommand.replace("cd", "");
		inputCommand = inputCommand.replace(" ", "");
				
		File changeFile = new File(change);
		
		for (int index = Constants.START; index < inputCommand.length(); index++) {

            if (inputCommand.substring(index, index+1).startsWith(".") || inputCommand.substring(index, index+1).startsWith("\\")) {
            }
            else {
            	location.setErrorMessage("지정된 경로를 찾을 수 없습니다.");
            	return false;
            };
        }
		
		
		try {
			location.setCurrentLocation(changeFile.getCanonicalPath().toString().replace("C:", ""));
			return true;
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return false;
	}
}
