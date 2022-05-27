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
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // ���� ��ġ ���
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
		System.out.println("����");
	}
	
	
	/*
	File f = new File("c:\\Users\\user\\OneDrive\\Desktop");
    if(f.isDirectory()) {
        System.out.println("���丮");  
    } else {
        System.out.println("������ ��θ� ã�� �� �����ϴ�.");            
    }*/

    
    //������ ���� ����
	//System.out.println(f.getAbsolutePath()); 
    //System.out.println("������ ���� ���� " + f.exists());
    //System.out.println("������ ũ�� " + f.length());
    //System.out.println("������ ������ ������¥ " + f.lastModified()/1000/86400);
    //System.getProperty ("user.home") ;
    //String home = System.getProperty("user.home");
    //System.out.println(location.getHome());
}