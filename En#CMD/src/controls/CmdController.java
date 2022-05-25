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
	        System.out.println("���丮");  
	    } else {
	        System.out.println("������ ��θ� ã�� �� �����ϴ�.");            
	    }*/
	    
		//System.out.println(CheckDirectoryAndStoreLocation(inputCommand));
		cd.CheckLocationOrError(inputCommand);
		//CheckLocationOrError(inputCommand);
		}
		/*
		 if(CheckDirectoryAndStoreLocation(inputCommand)) { // ��ΰ� ������ 
			 print.printCurrentLocation("C:" + location.getCurrentLocation(), CheckDirectoryAndStoreLocation(inputCommand));  // ���� ��ġ ���
		    } 
		 else {
			 print.printCurrentLocation(location.getCurrentLocation(), CheckDirectoryAndStoreLocation(inputCommand));  // ������ ��θ� ã�� �� �����ϴ� ��� 
		    }
		    */
	}
	
	private void CheckLocationOrError(String inputDirectory) {
		
		if(CheckDirectoryAndStoreLocation(inputDirectory)) { // ��ΰ� ������ 
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // ���� ��ġ ���
		    } 
		 else { // ��ΰ� ���� ������
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), Constants.IS_ERROR);  // ������ ��θ� ã�� �� �����ϴ� ��� 
		    }
	}
	
	private boolean CheckDirectoryAndStoreLocation(String inputDirectory) {
		//File f = new File("c:\\Users\\user\\OneDrive\\Desktop");
		 
		if(inputDirectory.contains("cd")) {
        String cdAndCommand[] =inputDirectory.split(" "); 
                 
		File directory = new File("\\" + cdAndCommand[Constants.COMMAND]);
		File currentLocation = new File(location.getCurrentLocation() + directory);
		
		
		 if(currentLocation.isDirectory()) {
			 location.setCurrentLocation(location.getCurrentLocation() + directory);  // ���� ��ġ ���� 
			 System.out.println("���丮 ��ġ ����");
		    } 
		 else {
			 location.setErrorMessage("������ ��θ� ã�� �� �����ϴ�.");            
		    }
		 
		 //System.out.println("directory=" + directory);
		 //System.out.println(location.getCurrentLocation());
		 return currentLocation.isDirectory(); // true�� ����, false�� ���� x
		}
		
	
		location.setErrorMessage("'"+inputDirectory+"'" + "��(��) ���� �Ǵ� �ܺ� ���, ������ �� �ִ� ���α׷�, �Ǵ� ��ġ ������ �ƴմϴ�."); // cd�� ���� ������ 
		return false;
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
