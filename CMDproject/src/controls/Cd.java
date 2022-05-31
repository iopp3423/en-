package controls;

import java.io.File;

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

	
	
	public void CheckLocationOrError(String inputDirectory) {
		
		if(CheckDirectoryAndStoreLocation(inputDirectory)) { // ��ΰ� ������ 
			if(location.getCurrentLocation().equals("")) { // root�����̸� 
				print.printCurrentLocation("C:\\" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);
			}
			else{
				print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // ���� ��ġ ���
			}
		 } 
		
		 else { // ��ΰ� ���� ������
			 print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), Constants.IS_ERROR);  // ������ ��θ� ã�� �� �����ϴ� ��� 
		    }
	}
	
	public boolean CheckDirectoryAndStoreLocation(String inputDirectory) {
		if(inputDirectory.equals("cd"))return true;
		else if(inputDirectory.equals("cd\\")) { // ó������ �̵�
			location.setCurrentLocation("");
			return true;
		}	
		else if(inputDirectory.equals("cd..")) return MoveOneStopUp();	
		else if(inputDirectory.equals("cd..\\..")) return MoveTwoStepUp();
		else if(inputDirectory.contains("cd ")) return actCd(inputDirectory);// cd���
		else {
			location.setErrorMessage("'"+inputDirectory+"'" + "��(��) ���� �Ǵ� �ܺ� ���, ������ �� �ִ� ���α׷�, �Ǵ� ��ġ ������ �ƴմϴ�."); // cd�� ���� ������ 
			return false;
		}
		
	}
	
	private boolean MoveOneStopUp() {
		int slashCount=Constants.RESET;
		String beforeCommand[] = location.getCurrentLocation().split("\\\\"); // \�������� ���ڿ� ���ø�
					
		slashCount = (data.countSlash(location.getCurrentLocation(), '\\')); // \ ��������
		location.setCurrentLocation(""); // �ʱ�ȭ
		
		for(int index=Constants.FIRST_LOCATION; index<slashCount; index++) {
			location.setCurrentLocation(location.getCurrentLocation() + "\\" +  beforeCommand[index]);
		}
		
		return true;
	}
	
	private boolean MoveTwoStepUp() {	
		int slashCount=Constants.RESET;
		String beforeCommand[] = location.getCurrentLocation().split("\\\\"); // \�������� ���ڿ� ���ø�
					
		slashCount = (data.countSlash(location.getCurrentLocation(), '\\')); // \ ��������
		location.setCurrentLocation(""); // �ʱ�ȭ
		
		for(int index=Constants.FIRST_LOCATION; index<slashCount-Constants.TWO_STEP_UP; index++) {
			location.setCurrentLocation(location.getCurrentLocation() +"\\" +  beforeCommand[index]);
		}
		return true;
	}

	
	private boolean actCd(String inputDirectory) {
		
		String cdAndCommand[] = inputDirectory.split(" ");
		File directory = new File("\\" + cdAndCommand[Constants.COMMAND]);
		File currentLocation = new File(location.getCurrentLocation() + directory);

		if(inputDirectory.contains("cd \\")){
			location.setErrorMessage("������ ��θ� ã�� �� �����ϴ�.\n");   
			return Constants.IS_ERROR;
		}
		else if(currentLocation.isDirectory()) {
			 location.setCurrentLocation(location.getCurrentLocation() + directory);  // ���� ��ġ ���� 
		    } 
		 else {
			 location.setErrorMessage("������ ��θ� ã�� �� �����ϴ�.");     
		    }
		 
		 return currentLocation.isDirectory(); // true�� ����, false�� ���� x
	}
	
}
