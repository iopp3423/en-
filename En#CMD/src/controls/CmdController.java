package controls;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Scanner;

import models.RouteLocation;
import utility.Constants;
import utility.InputCommand;
import views.PrintLocation;

public class CmdController {
	private Cd cd;
	private Cls cls;
	private Copy copy;
	private Dir dir;
	private Help help;
	private Move move;
	private InputCommand command;
	private RouteLocation location;
	private PrintLocation print;
	
	
	public CmdController() {
		command = new InputCommand();
		location = new RouteLocation();
		print = new PrintLocation();
		cd = new Cd(location, print);
		cls = new Cls();
		copy = new Copy();
		dir = new Dir();
		help = new Help();
		move = new Move();
	}
	
	public void cmdControl() {
		while(true) {
		String inputCommand = command.inputInstruction();
	
		/*
		File f = new File(inputCommand);
	    if(f.isDirectory()) {
	        System.out.println("디랙토리");  
	    } else {
	        System.out.println("지정된 경로를 찾을 수 없습니다.");            
	    }*/
	    
		//System.out.println(CheckDirectoryAndStoreLocation(inputCommand));
		cd.CheckLocationOrError(inputCommand);
		//CheckLocationOrError(inputCommand);
		}
		/*
		 if(CheckDirectoryAndStoreLocation(inputCommand)) { // 경로가 맞으면 
			 print.printCurrentLocation("C:" + location.getCurrentLocation(), CheckDirectoryAndStoreLocation(inputCommand));  // 현재 위치 출력
		    } 
		 else {
			 print.printCurrentLocation(location.getCurrentLocation(), CheckDirectoryAndStoreLocation(inputCommand));  // 지정된 경로를 찾을 수 없습니다 출력 
		    }
		    */
	}
	
	private void CheckLocationOrError(String inputDirectory) {
		
		if(CheckDirectoryAndStoreLocation(inputDirectory)) { // 경로가 맞으면 
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
		    } 
		 else { // 경로가 맞지 않으면
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), Constants.IS_ERROR);  // 지정된 경로를 찾을 수 없습니다 출력 
		    }
	}
	
	private boolean CheckDirectoryAndStoreLocation(String inputDirectory) {
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
	
	
	/*
	File f = new File("c:\\Users\\user\\OneDrive\\Desktop");
    if(f.isDirectory()) {
        System.out.println("디랙토리");  
    } else {
        System.out.println("지정된 경로를 찾을 수 없습니다.");            
    }*/

    
    //파일의 존재 여부
	//System.out.println(f.getAbsolutePath()); 
    //System.out.println("파일의 존재 여부 " + f.exists());
    //System.out.println("파일의 크기 " + f.length());
    //System.out.println("파일의 마지막 수정날짜 " + f.lastModified()/1000/86400);
    //System.getProperty ("user.home") ;
    //String home = System.getProperty("user.home");
    //System.out.println(location.getHome());
}
