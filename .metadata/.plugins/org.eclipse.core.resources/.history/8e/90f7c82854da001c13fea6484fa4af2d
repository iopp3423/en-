package controls;

import java.awt.Font;
import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import Utility.Constants;
import view.TextPanel;

public class supportText {
	
	private TextPanel textPanel;
	

	public supportText(TextPanel textPanel) {
		this.textPanel = textPanel;
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
	
	public String changeNumber(String number) { // 숫자 변경 
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
	
	public String deleteDotZeroNumber(String changedNumber) { // 3.0 === > 3 으로 변경ㅇ 
		
		String changed;
		DecimalFormat numberFormat = new DecimalFormat("0"); //형변환 Decimal	
		changed = numberFormat.format(Double.parseDouble(changedNumber));
		  return changed;
	}
	
	
	public void adjustFontSize() // 폰트 사이즈 조절 
	{
		int fontlength = textPanel.inputSpace.getText().length();
		switch(fontlength) {
		case 1 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 70));break;
		case 10 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 54));break;
		case 11 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 52));break;
		case 12 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 50));break;
		case 13 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 47));break;
		case 14 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 42));break;
		case 15 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 38));break;
		case 16 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 35));break;
		case 17 : textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 30));break;
		}
		if(fontlength>19) textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 30));
	}
	
	public void exceptionPrint() // 예외처리 함수 
	{
		if(textPanel.inputSpace.getText().contains("e")){ // 문자열 자르
			String longText = textPanel.inputSpace.getText();
			String[] textArray = longText.split("e");
			
			if(textArray[1].length()>5) textPanel.inputSpace.setText("오버플로");
		}		
	}
}
