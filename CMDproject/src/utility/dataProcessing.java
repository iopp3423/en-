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
}