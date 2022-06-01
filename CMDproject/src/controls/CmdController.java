package controls;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
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
		printVersion();
		location.setCurrentLocation(data.removeC(location.getCurrentLocation()));
	    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
	}
	
	public void cmdControl() {
		while(true) {
		String inputCommand = command.inputInstruction();
		String instruction = "";

		inputCommand = removeC(inputCommand);	

		
		if(inputCommand.length() >= Constants.INSTRUCTION) {
		instruction = inputCommand.substring(Constants.RESET, Constants.INSTRUCTION);
		}
		else instruction = inputCommand; // cd\, dir, cls입력시 바로 이동
		
		if(instruction.equals("")) print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력continue;
		else if(instruction.contains("dir")) GoDir.CheckcurrentLocationOrDesignateDir(inputCommand);
		else if(instruction.contains("cd"))GoCd.checkLocationOrError(inputCommand);
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

		else GoCd.checkLocationOrError(inputCommand);

		}	
	
	}
	private void printVersion() {
		try {
			String line;
			InputStream cmdNumber;
			cmdNumber = Runtime.getRuntime().exec("cmd").getInputStream();
			BufferedReader bufferReader = new BufferedReader(new InputStreamReader(cmdNumber, "MS949"));
			for(int index=Constants.START;index<Constants.CMD_NUMBER;index++) {
				line = bufferReader.readLine();
				print.printSentence(line + "\n");
			}
			System.out.println();
			bufferReader.close();
			cmdNumber.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	private String removeC(String inputCommand) {
		if(inputCommand.contains("C:\\") || inputCommand.contains("c:\\")) {

		
			if(inputCommand.contains("cd") || inputCommand.contains("dir")) {
				inputCommand = inputCommand.replace("C:\\", "");
				inputCommand = inputCommand.replace("c:\\", "");
				location.setCurrentLocation("");		
			}
			else {
				inputCommand = inputCommand.replace("C:\\", "\\");
				inputCommand = inputCommand.replace("c:\\", "\\");
			}
		}
		else if(inputCommand.contains("C:") || inputCommand.contains("c:")) {
			inputCommand = inputCommand.replace("C:", "");
			inputCommand = inputCommand.replace("c:", "");
			if(inputCommand.contains("cd") || inputCommand.contains("dir"))
				location.setCurrentLocation("");	
		}
		return inputCommand;
	}
}