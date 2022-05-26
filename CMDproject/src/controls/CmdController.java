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
	private Cd GoCd;
	private Cls GoCls;
	private Copy GoCopy;
	private Dir GoDir;
	private Move GoMove;
	private InputCommand command;
	private RouteLocation location;
	private PrintLocation print;
	
	
	public CmdController() {
		command = new InputCommand();
		location = new RouteLocation();
		print = new PrintLocation();
		GoCd = new Cd(location, print);
		GoCls = new Cls();
		GoCopy = new Copy();
		GoDir = new Dir(location, print);
		GoMove = new Move();
		print.printNotice();
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
	}
	
	public void cmdControl() {
		while(true) {
		String inputCommand = command.inputInstruction();
	

		if(inputCommand.contains("dir")) GoDir.printCurrentLocationDir();
		else if(inputCommand.contains("cd"))GoCd.CheckLocationOrError(inputCommand);
		else if (inputCommand.equals("help")) {
			print.printHelp();
			print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);
		}
		else GoCd.CheckLocationOrError(inputCommand);
		}
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