package controls;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import models.RouteLocation;
import utility.Constants;
import utility.dataProcessing;
import views.PrintLocation;

public class CmdController {
	private Cd GoCd;
	private Copy GoCopy;
	private Dir GoDir;
	private Moved GoMove;
	private dataProcessing command;
	private RouteLocation location;
	private PrintLocation print;
	private dataProcessing data;
	
	public CmdController() {
		command = new dataProcessing();
		location = new RouteLocation();
		print = new PrintLocation();
		data = new dataProcessing();
		GoCd = new Cd(location, print);
		GoCopy = new Copy();
		GoDir = new Dir(location, print, data);
		GoMove = new Moved(location, print);
		print.printNotice();
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
	}
	
	public void cmdControl() {
		while(true) {
		String inputCommand = command.inputInstruction();
		test(inputCommand);

		if(inputCommand.contains("dir")) GoDir.CheckcurrentLocationOrDesignateDir(inputCommand);
		else if(inputCommand.contains("cd"))GoCd.CheckLocationOrError(inputCommand);
		else if(inputCommand.contains("move"))GoMove.moveController(inputCommand);
		else if (inputCommand.equals("help")) {
			print.printHelp();
			print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);
		}
		else if(inputCommand.equals("cls")) {
			for(int index=Constants.RESET; index <Constants.CLS; index++) {
				print.printSentence("");
			}
			print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);
		}
		else GoCd.CheckLocationOrError(inputCommand);
		}
		
	}

	public void test(String sentence) {
		String change="";
		Pattern pattern = Pattern.compile(".+\\\\(?=.+)");
		
		Matcher matcher = pattern.matcher(sentence);
		while (matcher.find()) {
			System.out.println(matcher.group());
		}
		System.out.println("실패");
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