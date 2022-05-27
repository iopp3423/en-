package controls;

import java.io.File;

import models.RouteLocation;
import utility.Constants;
import views.PrintLocation;

public class Moved {
	private RouteLocation location;
	private PrintLocation print;
	
	public Moved(RouteLocation location, PrintLocation print) {
		this.location = location;
		this.print = print;
	}

	public void moveController(String inputCommand) {
		if(inputCommand.contains("move ") && !inputCommand.contains("\\")) MoveFileCurrentLocationToCurrentLocation(inputCommand);  //move a.txt b.txt
	}
	
	private void MoveFileCurrentLocationToCurrentLocation(String inputCommand) {
		String slicedSentence[];
		slicedSentence = sliceSentence(inputCommand);
		
		File oldfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

		if(oldfile.renameTo(newfile)){
			print.printMoveFileSucessOrFail("1개 파일을 이동했습니다.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("지정된 파일을 찾을 수 없습니다.", !Constants.IS_SUCESS);
		}
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	private String[] sliceSentence(String inputCommand) {
		String slicedSentence[] = inputCommand.split(" ");
				return slicedSentence;
	}
}
