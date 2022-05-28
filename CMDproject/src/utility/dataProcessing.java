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
		
		if(instruction.contains("C:") || instruction.contains("c:")) {
			instruction = instruction.replace("C:", "");
			instruction = instruction.replace("c:", "");
		}
		return instruction;
	}
	
	public boolean is_inputYesOrNo() {
		String instruction = scan.nextLine();
		
		if(instruction.equals("y") || instruction.equals("yes")) return true;
		if(instruction.equals("Y") || instruction.equals("Yes")) return true;
		else if(instruction.equals("n") || instruction.equals("no")) return false;
		else if(instruction.equals("N") || instruction.equals("No")) return false;
		else return true;
	}
	
	public String setComma(String number) { // ,찍기 
        String changeResult = number; // 출력할 결과를 저장할 변수
        Pattern pattern = Pattern.compile("(^[+-]?\\d+)(\\d{3})"); //정규표현식 
        Matcher regexMatcher = pattern.matcher(number); 
        
        while(regexMatcher.find()) {                
        	changeResult = regexMatcher.replaceAll("$1,$2"); //치환 
                                 	
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
}