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
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // ���� ��ġ ���
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