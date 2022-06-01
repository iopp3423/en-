package utility;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class dataProcessing {
	private Scanner scan;

	public dataProcessing() {
		scan = new Scanner(System.in);
	}
	
	public String inputInstruction() {
		String instruction = scan.nextLine();	
		 
		if(instruction.equals("dir..")) {
			instruction = instruction.replace("dir..", "dir ..");
		}
		if(instruction.contains("/")) {
			instruction = instruction.replace("/","\\");
		}
		if(instruction.contains("\\\\")) {
			instruction = instruction.replace("\\\\","\\");
		}
		if(instruction.contains(" .\\")) {	
		instruction = instruction.replace(".\\", "");
		}
		
		instruction = instruction.replaceAll("\\s+", " "); // �ߺ� ���� ����
		instruction = instruction.trim(); // ���ڿ� �� �� ���� ����
	
		return instruction;
	}
	
	public String removeC(String location){
		if(location.contains("C:")  || location.contains("c:")) {
			location = location.replace("C:", "");
			location = location.replace("c:", "");
		}
		return location;
	}
	
	public boolean isinputYesOrNo() {
		String instruction = scan.nextLine();
		
		instruction = capitalizeFirstLetter(instruction);
		if(instruction.equals("Y") || instruction.equals("Yes")) return true;
		else if(instruction.equals("N") || instruction.equals("No")) return false;
		else return true;
	}
	
	public String setComma(String number) { // ,��� 
        String changeResult = number; // ����� ����� ������ ����
        Pattern pattern = Pattern.compile("(^[+-]?\\d+)(\\d{3})"); //����ǥ���� 
        Matcher regexMatcher = pattern.matcher(number); 
        
        while(regexMatcher.find()) {                
        	changeResult = regexMatcher.replaceAll("$1,$2"); //ġȯ 
                                 	
            regexMatcher.reset(changeResult); 
        }        
        return changeResult;
    }
	
	public String[] sliceSentence(String inputCommand) {
		String slicedSentence[] = inputCommand.split(" ");
			return slicedSentence;
	}
	
	
	public int blankCount(String command, char string) { 
		
		int blankCount = Constants.RESET;         
		
		for (int index = Constants.START; index < command.length(); index++) {
			if (command.charAt(index) == string) { 
				blankCount++;            
				}        
			}        
		
		return blankCount;   
	}
	
	public int checkBlankAndSlash(String command, String blank) {
		int blankAndSlashCount = Constants.RESET;
		for (int index = Constants.RESET; index < command.length(); index++) {
            if (command.substring(index).startsWith(blank)) {
            	blankAndSlashCount++;
            }
        }
		
		
		return blankAndSlashCount;
	}
	
	public String extractFile(String sentence) {
		Pattern pattern = Pattern.compile("[^\\\\/\\n]+$");
		
		Matcher matcher = pattern.matcher(sentence);
		while (matcher.find()) {
			return matcher.group();
		}
		return "";
	}
	
	public String extractRoute(String sentence) {
		Pattern pattern = Pattern.compile(".+\\\\(?=.+)");
		
		Matcher matcher = pattern.matcher(sentence);
		while (matcher.find()) {
			return matcher.group();
		}
		return "";
	}
	
	public int countSlash(String command, char slash) { // \ ��������
		
		int slashCount = Constants.RESET;         
		
		for (int index = Constants.START; index < command.length(); index++) {
			if (command.charAt(index) == slash) { 
				slashCount++;            
				}        
			}        
		
		return slashCount;   
	}
	
	public String capitalizeFirstLetter(String str) {         
		// ù��° ���� substring        
		String firstLetter = str.substring(Constants.RESET, Constants.FIRST_CHAR);        
		// ù��° ���ڸ� ������ ������ ���� substring        
		String remainLetter = str.substring(Constants.FIRST_CHAR);         
		// ù��° ���ڸ� �빮�ڷ� ��ȯ        
		firstLetter = firstLetter.toUpperCase();        
		// ������ ���ڸ� �ҹ��ڷ� ��ȯ        
		remainLetter = remainLetter.toLowerCase();        
		// ù��° ����(�빮��) + ������ ����(�ҹ���)       
		String result = firstLetter + remainLetter;    
		
		return result;    
	}	
}