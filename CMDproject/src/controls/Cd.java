package controls;

import java.io.File;
import java.io.IOException;

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

	
	
	public void checkLocationOrError(String inputDirectory) {
		
		if(checkDirectoryAndStoreLocation(inputDirectory)) { // ��ΰ� ������ 
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
	
	public boolean checkDirectoryAndStoreLocation(String inputDirectory) {
		
		if(inputDirectory.equals("cd")) {
			print.printSentence("\n"); 
			return true;
		}
		else if(inputDirectory.equals("cd\\")) { // ó������ �̵�
			location.setCurrentLocation("");
			return true;
		}
		else if(inputDirectory.contains("..")) return moveStepUP(inputDirectory);		
		else if(inputDirectory.contains("cd ")) return actCd(inputDirectory);// cd���
		else{
			location.setErrorMessage("'"+inputDirectory+"'" + "��(��) ���� �Ǵ� �ܺ� ���, ������ �� �ִ� ���α׷�, �Ǵ� ��ġ ������ �ƴմϴ�."); // cd�� ���� ������ 
			return false;
		}
		
	}
	
	private boolean actCd(String inputDirectory) {
		
		String cdAndCommand[] = inputDirectory.split(" ");
		File directory = new File("\\" + cdAndCommand[Constants.COMMAND]);
		File currentLocation = new File(location.getCurrentLocation() + directory);
		File resetLocation = new File(cdAndCommand[Constants.COMMAND]);

		if(inputDirectory.contains("cd \\")){
			if(resetLocation.isDirectory()) {
				location.setCurrentLocation(resetLocation.toString());
				return !Constants.IS_ERROR;	
			}
			else {
				location.setErrorMessage("������ ��θ� ã�� �� �����ϴ�.\n");
				return Constants.IS_ERROR;
			}
		}
		else if(currentLocation.isDirectory()) {
			 location.setCurrentLocation(location.getCurrentLocation() + directory);  // ���� ��ġ ���� 
		    } 
		 else {
			 location.setErrorMessage("������ ��θ� ã�� �� �����ϴ�.");     
		    }
		 
		 return currentLocation.isDirectory(); // true�� ����, false�� ���� x
	}
	
	
	private boolean moveStepUP(String inputCommand) {
		
		String change = location.getCurrentLocation()+ "\\" + inputCommand;
	
		change = change.replace("cd", "");
		change = change.replace(" ", "");
		inputCommand = inputCommand.replace("cd", "");
		inputCommand = inputCommand.replace(" ", "");
				
		File changeFile = new File(change);
		
		for (int index = Constants.START; index < inputCommand.length(); index++) {

            if (inputCommand.substring(index, index+1).startsWith(".") || inputCommand.substring(index, index+1).startsWith("\\")) {
            }
            else {
            	location.setErrorMessage("������ ��θ� ã�� �� �����ϴ�.");
            	return false;
            };
        }
		
		
		try {
			location.setCurrentLocation(changeFile.getCanonicalPath().toString().replace("C:", ""));
			return true;
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return false;
	}
}
