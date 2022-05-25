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
		if(inputDirectory.equals("cd")) { // ó������ �̵�
			return true;
		}
		else if(inputDirectory.equals("cd\\")) { // ó������ �̵�
			location.setCurrentLocation("");
			return true;
		}
		
		else if(inputDirectory.equals("cd..")) { // 1�ܰ� ���� �̵�
			int slashCount=Constants.RESET;
			String beforeCommand[] = location.getCurrentLocation().split("\\\\"); // \�������� ���ڿ� ���ø�
						
			slashCount = (countChar(location.getCurrentLocation(), '\\')); // \ ��������
			location.setCurrentLocation(""); // �ʱ�ȭ
			
			for(int index=Constants.FIRST_LOCATION; index<slashCount; index++) {
				location.setCurrentLocation(location.getCurrentLocation() +"\\" +  beforeCommand[index]);
			}
			
			return true;
		}
		
		else if(inputDirectory.equals("cd..\\..")) { // 2�ܰ� ���� �̵�
			
			int slashCount=Constants.RESET;
			String beforeCommand[] = location.getCurrentLocation().split("\\\\"); // \�������� ���ڿ� ���ø�
						
			slashCount = (countChar(location.getCurrentLocation(), '\\')); // \ ��������
			location.setCurrentLocation(""); // �ʱ�ȭ
			
			for(int index=Constants.FIRST_LOCATION; index<slashCount-1; index++) {
				location.setCurrentLocation(location.getCurrentLocation() +"\\" +  beforeCommand[index]);
			}
			return true;
		}
		
		
		else if(inputDirectory.contains("cd")) {	
        String cdAndCommand[] =inputDirectory.split(" ");                 
		File directory = new File("\\" + cdAndCommand[Constants.COMMAND]);
		File currentLocation = new File(location.getCurrentLocation() + directory);
		
		//System.out.println(inputDirectory);
		//System.out.println(directory);
		//System.out.println(currentLocation);
		
		 if(currentLocation.isDirectory()) {
			 location.setCurrentLocation(location.getCurrentLocation() + directory);  // ���� ��ġ ���� 
			 System.out.println("���丮 ��ġ ����");
		    } 
		 else {
			 location.setErrorMessage("������ ��θ� ã�� �� �����ϴ�.");            
		    }
		 return currentLocation.isDirectory(); // true�� ����, false�� ���� x
		}
		
		else {
			location.setErrorMessage("'"+inputDirectory+"'" + "��(��) ���� �Ǵ� �ܺ� ���, ������ �� �ִ� ���α׷�, �Ǵ� ��ġ ������ �ƴմϴ�."); // cd�� ���� ������ 
			return false;
		}
	}



	public int countChar(String command, char slash) { // \ ��������
		
		int slashCount = Constants.RESET;         
		
		for (int index = Constants.START; index < command.length(); index++) {
			if (command.charAt(index) == slash) { 
				slashCount++;            
				}        
			}        
		
		return slashCount;   
	}	
}


//System.out.println("directory=" + directory);
//System.out.println(location.getCurrentLocation());