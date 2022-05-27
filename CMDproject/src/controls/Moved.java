package controls;

import java.io.File;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

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
		//  move a.txt b.txt
		else if(blankCount(inputCommand, ' ') == Constants.MOVE_CURRENT_TO_DESIGNATE_LOCATION) {
			MoveFileCurrentLocationToDestinationLocation(inputCommand);
			System.out.println("22222222");
		}
		// move a.txt users\\user\onedrive\desktop\b.txt
		else if(inputCommand.contains(" \\")) System.out.println("44444");
		// move\\users\\user\onedrive\desktop\a.txt \\users\\user\onedrive\desktop\b.txt
		else System.out.println("55555");
		// move\\users\\user\onedrive\desktop\a.txt b.txt
		// move\\users\\user\desktop\a.txt 
	}
	
	
	private void MoveFileCurrentLocationToCurrentLocation(String inputCommand) {
		String slicedSentence[];
		slicedSentence = sliceSentence(inputCommand);
		
		File oldfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_OLD_FILE]);
		File newfile = new File(location.getCurrentLocation() + "\\" + slicedSentence[Constants.CURRENT_LOACTION_NEW_FILE]);

		if(oldfile.renameTo(newfile)){
			print.printMoveFileSucessOrFail("1�� ������ �̵��߽��ϴ�.", Constants.IS_SUCESS);
		}
		else{
			print.printMoveFileSucessOrFail("������ ������ ã�� �� �����ϴ�.", !Constants.IS_SUCESS);
		}
		print.printSentence("C:" + location.getCurrentLocation() + ">");
	}
	
	
	public void MoveFileCurrentLocationToDestinationLocation(String inputCommand) {
		String file =  extractFile(inputCommand);  // move a.txt \\users\\user\onedrive\desktop\b.txt -> b.txt ����
		String route = extractRoute(inputCommand); // move a.txt \\users\\user\onedrive\desktop\ ����
		String fileAndLocation[];

		fileAndLocation = sliceSentence(route); // move a.txt \\users\\user\onedrive\desktop\  a.txt, ��� ����
		
		File newLocation = new File(fileAndLocation[Constants.LOCATION]); // ���丮 ��ġ
		File oldFile = new File(location.getCurrentLocation() + "\\" + fileAndLocation[Constants.FILE]); // ������ġ + ����
		File newFile = new File(newLocation + "\\" + file); // ������ġ + ����
		
		if(newLocation.isDirectory() && oldFile.renameTo(newFile)) { // ��� �°� ���� �̵� ����������
			System.out.println("������ �̵��Ͽ����ϴ�.");
		}
		else {
			print.printSentence("������ ��θ� ã�� �� �����ϴ�.\r\n"
							+ "     0�� ������ �̵��߽��ϴ�.");
		}		
	}
	
	
	private String[] sliceSentence(String inputCommand) {
		String slicedSentence[] = inputCommand.split(" ");
			return slicedSentence;
	}
	
	
	private int blankCount(String command, char string) { // ���� ��������
		
		int blankCount = Constants.RESET;         
		
		for (int index = Constants.START; index < command.length(); index++) {
			if (command.charAt(index) == string) { 
				blankCount++;            
				}        
			}        
		
		return blankCount;   
	}
	
	public String extractFile(String sentence) {
		Pattern pattern = Pattern.compile("[^\\\\/\\n]+$");
		
		Matcher matcher = pattern.matcher(sentence);
		while (matcher.find()) {
			//System.out.println(matcher.group());
			return matcher.group();
		}
		return "";
	}
	
	public String extractRoute(String sentence) {
		Pattern pattern = Pattern.compile(".+\\\\(?=.+)");
		
		Matcher matcher = pattern.matcher(sentence);
		while (matcher.find()) {
			//System.out.println(matcher.group());
			return matcher.group();
		}
		return "";
	}
}
