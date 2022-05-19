package controls;
import java.awt.Font;
import java.awt.GridBagLayout;
import java.awt.event.ActionEvent;

import Utility.Constants;
import models.OperatorData;
import view.CalculatorPanel;
import view.PrintCalculator;
import view.RecordPanel;
import view.TextPanel;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.math.BigDecimal;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import java.math.BigInteger;
import java.math.RoundingMode;
import java.text.DecimalFormat;



public class testClass{

	private PrintCalculator printCalculator;
	private CalculatorPanel calculatorPanel;
	private JScrollPane scrollPane;
	private TextPanel textPanel;
	private RecordPanel recordPanel;
	private OperatorData Data;
	
	private String text;
	private String record = "";
	private int limit; // 숫자 입력 제한 
	private int dotCount = Constants.RESET;
	private String number = "";
	private int pluscount = Constants.RESET;
	private int plusMinus = -Constants.ONE;
	private int buttonSize = Constants.RESET;

	
	public testClass(PrintCalculator printCalculator)
	{	
		this.printCalculator = printCalculator;
		calculatorPanel = new CalculatorPanel(actionlistener, keyAdapter);
		recordPanel = new RecordPanel();
		scrollPane = new JScrollPane(recordPanel);
		textPanel = new TextPanel(calculatorPanel, scrollPane, printCalculator, recordPanel);  //입력패드 생성 textPanel = new TextPanel(calculatorPanel, recordPanel);  //입력패드 생성 
		Data = new OperatorData();
		callCalculator();// 계산기 출력 
	}
	
	
	public void callCalculator() // 계산기 출력 
	{
		printCalculator.openCalculator(calculatorPanel, textPanel, recordPanel, scrollPane); // 계산기 출력	
	}
	

	ActionListener actionlistener = new ActionListener(){ // 누른 키패드 가져오기
		public void actionPerformed(ActionEvent e) {				
			text = (e.getActionCommand()); // 입력한  값 가져오기 				
			switch(text){
				case "0" : inputZero(); break;
				case "1" : inputNumber();break;
				case "2" : inputNumber();break;
				case "3" : inputNumber();break;
				case "4" : inputNumber();break;
				case "5" : inputNumber();break;
				case "6" : inputNumber();break;
				case "7" : inputNumber();break;
				case "8" : inputNumber();break;
				case "9" : inputNumber();break;
				case "\u232B": delete(); break;
				case "C" : reset(); break;
				case "CE": resetPart(); break;
				case "±" : changeSign(); break;
				case "." : inputDot(); break;
				case "=" : result(); break;
				case "x" : combineCalculate(); break;
				case "+" : combineCalculate(); break;
				case "-" : combineCalculate(); break;
				case "÷" : combineCalculate(); break;
			}	
			adjustFontSize();
		}
		
	};
	
	
	
	KeyAdapter keyAdapter = new KeyAdapter() {
		public void keyPressed(KeyEvent e) {
			System.out.println(e.getKeyCode());		
			switch(e.getKeyCode()) {			
			case 48 : text = "0"; inputNumber(); break;
			case 49 : text = "1"; inputNumber(); break;
			case 50 : text = "2"; inputNumber(); break;
			case 51 : text = "3"; inputNumber(); break;
			case 52 : text = "4"; inputNumber(); break;
			case 53 : text = "5"; inputNumber(); break;
			case 54 : text = "6"; inputNumber(); break;
			case 55 : text = "7"; inputNumber(); break;
			case 56 : text = "8"; inputNumber(); break;
			case 57 : text = "9"; inputNumber(); break;
			case 10 : text = "="; result(); break;
			case 107 : text = "+"; combineCalculate(); break;
			case 109 : text = "-"; combineCalculate(); break;
			case 47 : text = "÷"; combineCalculate(); break;
			case 106 : text = "x"; combineCalculate();  break;
			case 8: text = "\u232B"; delete(); break;
			case 27: text = "C"; reset(); break;
			}
			
			adjustFontSize();
			
		}
	};
	
		
	private void delete() 
	{	
		String inputRecord;
		
		pluscount = Constants.RESET;
		
		if(Data.getFormula() == "=") { /// 계산하고 바로 지울 때 중간값만 지우기 
			
			 for(int index=textPanel.inputSpace.getText().length(); index>Constants.RESET; index--)
				{
					if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
		             {
						 textPanel.blankSpace.setText(setComma(" ")); // 중간 값 
						 number = "0";
		             }
				}
		 }
		 
		
		 else if (textPanel.inputSpace.getText().length() == Constants.ONE)   //글자수가 1일 때  백스페이스 누르면 0으로 초기
         {
			 textPanel.inputSpace.setText("0");
			 number = "0";
			 record = "";
         }
		
		 if(textPanel.inputSpace.getText().length() != Constants.ONE) //글자수 1 아니면 
		 {
			 inputRecord = record.substring(Constants.RESET,record.length()-Constants.ONE); // 문자열자르기
			 textPanel.inputSpace.setText(setComma(inputRecord));
			 
			 number = inputRecord; //지운만큼 넘버값 줄이기 
			 record = inputRecord;
		 }

	}
	
	
	private void inputZero()
	{
		
		if(text.equals("0"))
		{
			if(textPanel.inputSpace.getText() == "0") {
				textPanel.inputSpace.setText("0");
			}
			else if(limit<Constants.LIMIT_INPUT)
			{				 		
				record += text;// 키보드 입력
				number = record; //// 넘버에 입력값 넣어주기
				textPanel.inputSpace.setText(setComma(record));			
				//System.out.println("number="+number);
			}
			limit = record.length();	
		}
	}
	
	
	private void inputNumber() // 입력 
	{		
		if(limit<Constants.LIMIT_INPUT) 
		{	
			if(Data.getFormula().equals("=")) { // 계산하고 바로 숫자패드 입력 시초기
				reset();
			}
			
			record += text;// 입력
					
			if(pluscount % 2 == 1) {
				textPanel.inputSpace.setText("-" + setComma(record)); //pluscount 홀수면 - 붙혀서 출력하
				//number = record * plusMinus; //// 넘버에 입력값 넣어주기
			}
			else if(textPanel.inputSpace.getText().equals("0")){ // 0밖에 없으
				textPanel.inputSpace.setText("");  // 0 없애기  
				textPanel.inputSpace.setText(setComma(record));
				number = record; //// 넘버에 입력값 넣어주기
			}
			else {
				textPanel.inputSpace.setText(setComma(record));
				number = record; //// 넘버에 입력값 넣어주기
			}	
			
		}
		limit = record.length();
	}
	
	
	private void reset() // C
	{
		number = "0";
		limit = Constants.RESET;
		pluscount = Constants.RESET;
		record = "";
		Data.setOperator("=");
		Data.setFormula("");
		dotCount=Constants.RESET;
		Data.setResult("0");
		Data.setTemp("0");
		textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 50)); 
		
		for(int index=textPanel.inputSpace.getText().length(); index>Constants.RESET; index--)
		{
			if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
             {
				 textPanel.inputSpace.setText("0");
				 textPanel.blankSpace.setText(" "); // 중간 값 
             }
		}
		
	}
	
	private void resetPart() // CE
	{
		
		pluscount = Constants.RESET;
		record = "";
		number = "0";
		dotCount = Constants.RESET;
		textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 50));
		
		for(int index=textPanel.inputSpace.getText().length(); index>Constants.RESET; index--)
		{
			if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
             {
				 textPanel.inputSpace.setText("0");
             }
		}
		
	}
	
	private void changeSign()
	{
		
		if(textPanel.inputSpace.getText() == "0") { // 0 이면 +- 안붙
			textPanel.inputSpace.setText("0");
		}
		
		else if(textPanel.inputSpace.getText() != "0"){ // 0이 아니면 
			
		//number *= plusMinus;	
		pluscount++;
		
		if(pluscount % 2 == Constants.ONE) { // 짝수면 플러스, 홀수면 마이너스 
			
			if(record == "") textPanel.inputSpace.setText("-" + (Data.getTemp())); // 홀수이면서 2 -> 사칙연산 -> +-눌렀을 
			else if (record != "") textPanel.inputSpace.setText("-" + setComma(record)); //그냥 +-
		}
		
		
		else {
			if(record == "") textPanel.inputSpace.setText(setComma(Data.getTemp()));// 짝이면서 2 -> 사칙연산 -> +-눌렀을 
			else if (record != "") textPanel.inputSpace.setText(setComma(record));//그냥 +-
		}	
	}
		
	}
	
	private void inputDot() // 소수점 
	{
			
		if(textPanel.inputSpace.getText().equals("0")) { // 0일 때 
			record += "0" + text;// 키보드 입력한 값	
			textPanel.inputSpace.setText(setComma(record));
			dotCount++;		
		}
		
		if (dotCount == Constants.RESET && !(textPanel.inputSpace.getText().equals("0"))) { // 0제외 
			record += text;// 키보드 입력한 값	
			
			textPanel.inputSpace.setText(record);
			dotCount++;		
		}
		
		/*
		if(result == "0" && record.equals(".")) { // 2.5 - negate. -> 0
			textPanel.inputSpace.setText(result + record);
			dotCount++;	
		}
		*/
		if(Data.getResult() == "0" && record.equals(".")) { // 2.5 - negate. -> 0
			textPanel.inputSpace.setText(Data.getResult() + record);
			dotCount++;	
		}	
		
	}
	
	
	private void result(){ // 결
		
		pluscount = Constants.RESET;
		
		if(number == "0") number = Data.getTemp(); // 2X4=, 2+5= 형식 처리  
		
		printResult();

		if(!Data.getOperator().equals(text)) { // 2 x 5 = 10 
		textPanel.blankSpace.setText(changeNumber(Data.getTemp()) + Data.getOperator() + number + text );
		textPanel.inputSpace.setText(setComma(changeNumber(Data.getResult())));
		}
		//changeNumber(Data.getResult());
		
		//textPanel.inputSpace.setText(setComma(result));
							
		/////////////////////////////////////////////////////////////////////////////////////////
				
		else if(Data.getOperator().equals(text)){//.equals(text)) { // 0.1 =====
			textPanel.blankSpace.setText(number+ text);
			textPanel.inputSpace.setText(setComma(number));
		
			if(Double.parseDouble(number) % Constants.CHECK_DECIMAL == Constants.RESET) { // 3.0 = 입력시 정수로 출력 
				textPanel.blankSpace.setText(deleteDotZeroNumber(number)+text);
				textPanel.inputSpace.setText(setComma(deleteDotZeroNumber(number)));
			}
		}
		/////////////////////////////////////////////////////////////////////////////////////////
		
		if(buttonSize == 20) buttonSize = Constants.RESET;
		recordPanel.button[buttonSize++].setText("<HTML>"+textPanel.blankSpace.getText() +"<br>"+ textPanel.inputSpace.getText()); //로그 남기기 
		exceptionPrint(); // 예외 문
		adjustFontSize(); // 사이즈 조
		Data.setFormula("=");
	}
	
	
	private void printResult() // 결과값 출력(중앙 출력)
	{
		
		if(!Data.getFormula().equals("=")) { // 2x4 = 8 
			switch(Data.getOperator()) {
			case "+" : Data.setResult(calculation(Data.getTemp(), number, "+")); break;
			case "-" : Data.setResult(calculation(Data.getTemp(), number, "-")); break;
			case "x" : Data.setResult(calculation(Data.getTemp(), number, "x"));break;
			case "÷" : Data.setResult(calculation(Data.getTemp(), number, "÷")); break;
			}
		}
		
		if(Data.getFormula().equals("=")) { //계산 후 바로 = 이 눌리면 
			Data.setTemp(Data.getResult());	
			textPanel.blankSpace.setText(changeNumber(Data.getResult()) + Data.getOperator() + number + text);
			
			switch(Data.getOperator()) {
			case "+" : Data.setResult(calculation(Data.getTemp(), number, "+")); break;
			case "-" : Data.setResult(calculation(Data.getTemp(), number, "-")); break;
			case "x" : Data.setResult(calculation(Data.getTemp(), number, "x"));break;
			case "÷" : Data.setResult(calculation(Data.getTemp(), number, "÷")); break;
			}
			
			textPanel.inputSpace.setText(setComma(changeNumber(Data.getResult())));// 결과값 출력
		}
		exceptionPrint();
	}
	
	
	private void combineCalculate() //사칙연산 안에 계산 함수들 묶는용
	{
		if(textPanel.blankSpace.getText().equals(" ")) Data.setTemp(number);
		calculate();
		setCalculate();
		printCalculate();
	}
	
	
	private void calculate()
	{
		if(textPanel.blankSpace.getText().contains("+")) Data.setTemp(calculation(Data.getTemp(), number, "+"));
		else if(textPanel.blankSpace.getText().contains("-"))Data.setTemp(calculation(Data.getTemp(), number, "-"));
		else if(textPanel.blankSpace.getText().contains("x")) Data.setTemp(calculation(Data.getTemp(), number, "x"));
		else if(textPanel.blankSpace.getText().contains("÷")) Data.setTemp(calculation(Data.getTemp(), number, "÷"));
	}
	
	private void printCalculate() // 화면에 값 출력 
	{
		
		textPanel.blankSpace.setText(Data.getTemp() +  text); // 중앙 화면
		textPanel.inputSpace.setText(setComma(Data.getTemp())); // 입력화면 	
		adjustFontSize(); // 사이즈 조
		exceptionPrint();
		record=""; // 입력값 초기화 
	}
	
	private void setCalculate() // 수식에 들어올 때 세팅 
	{
		if(Data.getTemp().equals(""))Data.setTemp("0"); // 계산기 입력 없을 때 연산자 누르면 널값이 아닌 0이 올라감 
		number = "0"; // number 초기화 
		dotCount = Constants.RESET;
		Data.setFormula("");
		Data.setOperator(text); // 부호 넣어주기 
		pluscount = Constants.RESET;
	}
	
	private void exceptionPrint() // 예외처리 함수 
	{
		String errorMessage = textPanel.inputSpace.getText();
		switch(errorMessage) {
		case "NaN" : textPanel.inputSpace.setText("정의되지 않은 결과입니다."); break;
		case "Infinity" : textPanel.inputSpace.setText("0으로 나눌 수 없습니다."); break;
		}
		
		if(Data.getOperator().equals("÷") && record.equals("0")) {
			textPanel.inputSpace.setText("0으로 나눌 수 없습니다.");
		}
	}
	
	
	private String setComma(String number) { // ,찍기 
        String changeResult = number; //출력할 결과를 저장할 변수
        Pattern pattern = Pattern.compile("(^[+-]?\\d+)(\\d{3})"); //정규표현식 
        Matcher regexMatcher = pattern.matcher(number); 
        
        while(regexMatcher.find()) {                
        	changeResult = regexMatcher.replaceAll("$1,$2"); //치환 
                                 	
            regexMatcher.reset(changeResult); 
        }        
        return changeResult;
    }
	

	
	private String calculation(String temp, String number, String operator) { // 결과 
		BigDecimal leftNumber = new BigDecimal(temp);
		BigDecimal rightNumber = new BigDecimal(number);
		BigDecimal result = new BigDecimal("0");
		BigDecimal set = new BigDecimal("0");
		String checkLastChar;
				
		//if(number == "0") return "0으로 나눌 수 없습니다.";
		System.out.println(temp);
		System.out.println(number);
		
		try{
			switch(operator) {  // 저장했던 연산
			case "+": result = leftNumber.add(rightNumber);break;
			case "-": result = leftNumber.subtract(rightNumber);break;
			case "÷": result = leftNumber.divide(rightNumber, 15, RoundingMode.HALF_EVEN);break;
			case "x": result = leftNumber.multiply(rightNumber); break;	
			}
		}
		catch (java.lang.ArithmeticException e){
		}

		/*
		checkLastChar = result.toString().substring(result.toString().length()-Constants.ONE);	
		if(checkLastChar == "0") set = result.stripTrailingZeros(); // 끝자리가 0 이면 0 없애
		else if(result.toString().contains(".")) set = result.setScale(15, RoundingMode.HALF_EVEN); // 아니면 반올림7
		else set = result;*/
		//if(temp.equals("0")) result = set;
		
		return result.toString();
	}
	
	
	private void adjustFontSize()
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
	
	
	private String deleteDotZeroNumber(String changeNumber) {
		
		String changed;
		DecimalFormat numberFormat = new DecimalFormat("0"); //형변환 Decimal	
		changed = numberFormat.format(Double.parseDouble(changeNumber));
		  return changed;
	}
	
	
	private String changeNumber(String number) {
		DecimalFormat format=new DecimalFormat();
		String changedNumber;
		BigDecimal newNumber = new BigDecimal(number);
		
		
		String patterns[]= {
				"#.###############E0",		// 16글자 넘어가면 E로 바껴서 출
				"###.##############" // 뒤에 소수점 0나오면 없게 출력, 반올림 포
		};
			
		format.applyPattern(patterns[1]);
		changedNumber = format.format(newNumber); // 뒤에 소수점 0나오면 없게 출력, 반올림 포함 먼저 정
		
		if(changedNumber.length() > 16) {
			format.applyPattern(patterns[0]);
		}

		changedNumber = format.format(Double.parseDouble(changedNumber));
		
		if(changedNumber.contains("E")) {
			changedNumber = changedNumber.replace("E","e");
		}

		return changedNumber;
		
	}
	
}
	
	
	
	




