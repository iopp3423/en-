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
		
		if(CheckDirectoryAndStoreLocation(inputDirectory)) { // ��ΰ� ������ 
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // ���� ��ġ ���
		    } 
		 else { // ��ΰ� ���� ������
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), Constants.IS_ERROR);  // ������ ��θ� ã�� �� �����ϴ� ��� 
		    }
	}
	
	public boolean CheckDirectoryAndStoreLocation(String inputDirectory) {
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
}
