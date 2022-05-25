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
		print.printNotice();
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // ���� ��ġ ���
	}
	
	public void cmdControl() {
		while(true) {
		String inputCommand = command.inputInstruction();
	

		cd.CheckLocationOrError(inputCommand);
		
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
