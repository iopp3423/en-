package controls;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class supportText {

	
	
	
	
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
	
	public String changeNumber(String number) {
		if(number.equals("Nan")) return "정의되지 않은 결과입니다.";
		if(number.equals("")) {
			return "0으로 나눌 수 없습니다.";
		}
		

		DecimalFormat format=new DecimalFormat();
		String changedNumber="";
		BigDecimal newNumber = new BigDecimal(number);
		
		String patterns[]= {
				"#.###############E0",		// 16글자 넘어가면 E로 바껴서 출
				//"###.##########################"  // 뒤에 소수점 0나오면 없게 출력, 반올림 포
				"###.###############"  // 뒤에 소수점 0나오면 없게 출력, 반올림 포
				//"###.##############"  // 뒤에 소수점 0나오면 없게 출력, 반올림 포
		};
		
		if(number.length() > 16) {
			format.applyPattern(patterns[0]);
			changedNumber = format.format(newNumber);
		}

		else if(number.contains(".")) {
			format.applyPattern(patterns[1]);
			changedNumber = format.format(newNumber); // 뒤에 소수점 0으로 끝나 없게 출력, 반올림 포함 먼저 정

		}
		else changedNumber = newNumber.toString();

		
		if(changedNumber.contains("E-")) { // E e 로 변
			changedNumber = changedNumber.replace("E","e");
		}
		
		else if(changedNumber.contains("E")) { // E e 로 변
			changedNumber = changedNumber.replace("E","e+");
		}
		
		return changedNumber;
		
	}
	
	public String deleteDotZeroNumber(String changedNumber) {
		
		String changed;
		DecimalFormat numberFormat = new DecimalFormat("0"); //형변환 Decimal	
		changed = numberFormat.format(Double.parseDouble(changedNumber));
		  return changed;
	}
}
