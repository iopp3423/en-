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
		GoCd = new Cd(location, print, data);
		GoCopy = new Copy(location, print, data);
		GoDir = new Dir(location, print, data);
		GoMove = new Moved(location, print, data);
		print.printNotice();
		location.setCurrentLocation(data.removeC(location.getCurrentLocation()));
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
	}
	
	public void cmdControl() {
		while(true) {
		String inputCommand = command.inputInstruction();
		String instruction = "";
		
		if(inputCommand.length() >= Constants.INSTRUCTION) {
		instruction = inputCommand.substring(Constants.RESET, Constants.INSTRUCTION);
		}
		else instruction = inputCommand; // cd\, dir, cls입력시 바로 이동
		
		
		if(instruction.contains("dir")) GoDir.CheckcurrentLocationOrDesignateDir(inputCommand);
		else if(instruction.contains("cd"))GoCd.CheckLocationOrError(inputCommand);
		else if(instruction.contains("move"))GoMove.controlMove(inputCommand);
		else if(instruction.contains("copy"))GoCopy.controlCopy(inputCommand);
		else if (instruction.equals("help")) {
			print.printHelp();
			print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);
		}
		else if(instruction.equals("cls")) {
			for(int index=Constants.RESET; index <Constants.CLS; index++) {
				print.printSentence("\n");
			}
			print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);
		}

		else GoCd.CheckLocationOrError(inputCommand);

		}	
	}

}