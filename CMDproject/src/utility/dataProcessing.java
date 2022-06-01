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
		
		instruction = instruction.replaceAll("\\s+", " "); // 중복 공백 제거
		instruction = instruction.trim(); // 문자열 앞 뒤 공백 제거
	
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
	
	public int countSlash(String command, char slash) { // \ 개수세기
		
		int slashCount = Constants.RESET;         
		
		for (int index = Constants.START; index < command.length(); index++) {
			if (command.charAt(index) == slash) { 
				slashCount++;            
				}        
			}        
		
		return slashCount;   
	}
	
	public String capitalizeFirstLetter(String str) {         
		// 첫번째 글자 substring        
		String firstLetter = str.substring(Constants.RESET, Constants.FIRST_CHAR);        
		// 첫번째 글자를 제외한 나머지 글자 substring        
		String remainLetter = str.substring(Constants.FIRST_CHAR);         
		// 첫번째 글자를 대문자로 변환        
		firstLetter = firstLetter.toUpperCase();        
		// 나머지 글자를 소문자로 변환        
		remainLetter = remainLetter.toLowerCase();        
		// 첫번째 글자(대문자) + 나머지 글자(소문자)       
		String result = firstLetter + remainLetter;    
		
		return result;    
	}	
}