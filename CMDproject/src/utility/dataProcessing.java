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
}