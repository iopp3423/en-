package controls;
import java.awt.Font;
import java.awt.GridBagLayout;
import java.awt.event.ActionEvent;

import Utility.Constants;
import models.OperatorData;
import models.inputData;
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



public class testClass{

	private PrintCalculator printCalculator;
	private CalculatorPanel calculatorPanel;
	private JScrollPane scrollPane;
	private TextPanel textPanel;
	private RecordPanel recordPanel;
	private OperatorData operatorData;
	private String text;
	private String inputRecord;
	private String record = "";
	private String math="=";
	private String formula="";
	private String centerProperty;
	//private double result = Constants.RESET;
	private String result = "";
	//private double temp = Constants.RESET;
	private String temp;
	private int length; // 길이 
	private int limit; // 숫자 입력 제한 
	private int dotCount = Constants.RESET;
	//private double number = Constants.RESET;
	private String number = "";
	private int pluscount = Constants.RESET;
	private int plusMinus = -Constants.ONE;
	private int fontsize=9;
	private int buttonSize = Constants.RESET;

	
	public testClass(PrintCalculator printCalculator, inputData data)
	{	
		this.printCalculator = printCalculator;
		calculatorPanel = new CalculatorPanel(actionlistener, keyAdapter);
		recordPanel = new RecordPanel();
		scrollPane = new JScrollPane(recordPanel);
		textPanel = new TextPanel(calculatorPanel, scrollPane, printCalculator, recordPanel);  //입력패드 생성 textPanel = new TextPanel(calculatorPanel, recordPanel);  //입력패드 생성 
		operatorData = new OperatorData();
		callCalculator();// 계산기 출력 
	}
	
	
	public void callCalculator() // 계산기 출력 
	{
		printCalculator.getCalculator(calculatorPanel, textPanel, recordPanel, scrollPane); // 계산기 출력	
	}
	

	ActionListener actionlistener = new ActionListener(){ // 누른 키패드 가져오기
		public void actionPerformed(ActionEvent e) {				
			text = (e.getActionCommand()); // 입력한  값 가져오기 
			length = textPanel.inputSpace.getText().length(); // 입력패드의 길이 가져오기			
			centerProperty = textPanel.blankSpace.getText(); // 중간 화면 값 가져오기 
			
			switch(text){
				case "\u232B": delete(); break;
				case "C" : reset(); break;
				case "CE": resetPart(); break;
				case "±" : changeSign(); break;
				case "." : inputDot(); break;
				case "=" : result(); break;
			}	
			inputdata(); // 키패드 
			arithmaticCalculate();
			
			if(length>8 && length<21) textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 50-fontsize));  	// 마지
			fontsize+=Constants.ONE;
		}
		
	};
	
	
	
	KeyAdapter keyAdapter = new KeyAdapter() {
		public void keyPressed(KeyEvent e) {
			System.out.println(e.getKeyCode());
			length = textPanel.inputSpace.getText().length(); // 입력패드의 길이 가져오기			
			centerProperty = textPanel.blankSpace.getText(); // 중간 화면 값 가져오기 
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
			case 107 : text = "+"; arithmaticCalculate(); break;
			case 109 : text = "-"; arithmaticCalculate(); break;
			case 10 : text = "="; result(); break;
			case 47 : text = "÷"; arithmaticCalculate(); break;
			case 106 : text = "x"; arithmaticCalculate();  break;
			case 8: text = "\u232B"; delete(); break;
			case 27: text = "C"; reset(); break;
			}
			
			if(length>8 && length<21) {
				textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 50-fontsize));  	// 마지
			}
			fontsize+=Constants.ONE;
			
		}
	};
	KeyAdapter keyoverride = new KeyAdapter() {
		public void keyReleased(KeyEvent e) {
			System.out.println(e.getKeyCode());
			length = textPanel.inputSpace.getText().length(); // 입력패드의 길이 가져오기			
			centerProperty = textPanel.blankSpace.getText(); // 중간 화면 값 가져오기 
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
			case 107 : text = "+"; arithmaticCalculate(); break;
			case 109 : text = "-"; arithmaticCalculate(); break;
			case 10 : text = "="; result(); break;
			case 47 : text = "÷"; arithmaticCalculate(); break;
			case 106 : text = "x"; arithmaticCalculate();  break;
			case 8: text = "\u232B"; delete(); break;
			case 27: text = "C"; reset(); break;
			}
			
			if(length>8 && length<21) {
				textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 50-fontsize));  	// 마지
			}
			fontsize+=Constants.ONE;
			
		}
	};
	
		
	private void delete() 
	{	
		pluscount = Constants.RESET;
		
		if(formula == "=") { /// 계산하고 바로 지울 때 중간값만 지우기 
			
			 for(int index=length; index>Constants.RESET; index--)
				{
					if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
		             {
						 textPanel.blankSpace.setText(" "); // 중간 값 
						 number = "0";
		             }
				}
		 }
		 
		
		 else if (length == Constants.ONE)   //글자수가 1일 때  백스페이스 누르면 0으로 초기
         {
			 textPanel.inputSpace.setText("0");
			 number = "0";
			 record = "";
         }
		
		 if(length != Constants.ONE) //글자수 1 아니면 
		 {
			 inputRecord = record.substring(Constants.RESET,record.length()-Constants.ONE); // 문자열자르기
			 textPanel.inputSpace.setText(inputRecord);
			 
			 number = inputRecord; //지운만큼 넘버값 줄이기 
			 record = inputRecord;
		 }

	}
	
	
	private void inputdata()
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
		switch(text) {
		case "1" : inputNumber();break;
		case "2" : inputNumber();break;
		case "3" : inputNumber();break;
		case "4" : inputNumber();break;
		case "5" : inputNumber();break;
		case "6" : inputNumber();break;
		case "7" : inputNumber();break;
		case "8" : inputNumber();break;
		case "9" : inputNumber();break;
		}

	}
	
	
	private void inputNumber() // 입력 
	{		
		if(limit<Constants.LIMIT_INPUT) 
		{	
			if(formula.equals("=")) { // 계산하고 바로 숫자패드 입력 시초기
				reset();
			}
			
			record += text;// 입력
			System.out.println(record);		
			
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
		
		limit = Constants.RESET;
		pluscount = Constants.RESET;
		record = "";
		math = "=";
		formula = "";
		dotCount=Constants.RESET;
		result = "0";
		temp = "0";;
		fontsize=9;
		textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 50)); 
		for(int index=length; index>Constants.RESET; index--)
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
		fontsize=9;
		textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.RESET, 50));
		
		for(int index=length; index>Constants.RESET; index--)
		{
			if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
             {
				 textPanel.inputSpace.setText("0");
             }
		}
		
	}
	
	public void changeSign()
	{
		
		if(textPanel.inputSpace.getText() == "0") { // 0 이면 +- 안붙
			textPanel.inputSpace.setText("0");
		}
		
		else if(textPanel.inputSpace.getText() != "0"){ // 0이 아니면 
			
		//number *= plusMinus;	
		pluscount++;
		
		if(pluscount % 2 == Constants.ONE) { // 짝수면 플러스, 홀수면 마이너스 
			
			if(record == "") textPanel.inputSpace.setText("-" + (temp)); // 홀수이면서 2 -> 사칙연산 -> +-눌렀을 
			else if (record != "") textPanel.inputSpace.setText("-" + setComma(record)); //그냥 +-
		}
		
		
		else {
			if(record == "") textPanel.inputSpace.setText(setComma(temp));// 짝이면서 2 -> 사칙연산 -> +-눌렀을 
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
		
		if(result == "0" && record.equals(".")) { // 2.5 - negate. -> 0
			textPanel.inputSpace.setText(result + record);
			dotCount++;	
		}	
		
	}
	
	private void arithmaticCalculate()
	{
		switch(text) {
		case "+" : combineCalculate(); break;
		case "-" : combineCalculate(); break;
		case "x" : combineCalculate(); break;
		case "÷" : combineCalculate(); break;
		}
	}
		
	
	private void result(){ // 결
				
		
		pluscount = Constants.RESET;
		
		if(number == "0") number = temp; // 2X4=, 2+5= 형식 처리  
		
		printResult();

		textPanel.blankSpace.setText(temp + math + number + text );
		textPanel.inputSpace.setText(setComma(result));
							
		/////////////////////////////////////////////////////////////////////////////////////////
				
		if(math.equals(text)) { // 0.1 =====
			textPanel.blankSpace.setText(number + text);
			textPanel.inputSpace.setText(number);
		}
		 	
		/////////////////////////////////////////////////////////////////////////////////////////
	
		if(result.contains("E")) { // e로 변환하기 - 한 번 더 봐야
			textPanel.inputSpace.setText(setComma(result));
		}
		
		recordPanel.button[buttonSize++].setText("<HTML>"+textPanel.blankSpace.getText() +"<br>"+ textPanel.inputSpace.getText()); //로그 남기기 
		exceptionPrint(); // 예외 문
		
		System.out.println(temp);
		formula = "=";// formula 가 = 이면 바로 = 눌러서 계산한	
	}
	
	
	public void printResult() // 결과값 출력(중앙 출력)
	{
		
		if(!formula.equals("=")) { // 2x4 = 8 
			switch(math) {
			case "+" : result = calculation(temp, number, "+"); break;
			case "-" : result = calculation(temp, number, "-"); break;
			case "x" : result = calculation(temp, number, "x");break;
			case "÷" : result = calculation(temp, number, "÷"); break;
			}
		}
		
		if(formula.equals("=")) { //계산 후 바로 = 이 눌리면 
			
			textPanel.blankSpace.setText(result + math + number + text);
			
			temp = result;		
			switch(math) {
			case "+" : result = calculation(temp, number, "+"); break;
			case "-" : result = calculation(temp, number, "-"); break;
			case "x" : result = calculation(temp, number, "x");break;
			case "÷" : result = calculation(temp, number, "÷"); break;
			}
			
			textPanel.inputSpace.setText(setComma(result)); // 결과값 출력
		}
		System.out.println(temp);
		exceptionPrint();
	}
	
	private void combineCalculate() //사칙연산 안에 계산 함수들 묶는용
	{
		if(centerProperty.equals(" ")) temp = number;
		calculate();
		setCalculate();
		printCalculate();
	}
	
	
	private void printCalculate() // 화면에 값 출력 
	{

		textPanel.blankSpace.setText(temp +  text); // 중앙 화면
		//textPanel.inputSpace.setText(setComma(temp)); // 입력화면 	
		textPanel.inputSpace.setText(setComma(temp)); // 입력화면 	
		exceptionPrint();
		record=""; // 입력값 초기화 
		System.out.println(temp);
		System.out.println(text);
	}
	
	private void setCalculate() // 수식에 들어올 때 세팅 
	{
		number = "0"; // number 초기화 
		//record=""; // 입력값 초기화 
		dotCount = Constants.RESET;
		formula = ""; // "=" 초기
		math = text; // math 에 부호 넣어주
		pluscount = Constants.RESET;
	}
	
	private String changeDataType(double data) // 데이터 타입 변
	{
		//BigDecimal BigC = new BigDecimal(String.valueOf(data));
		//BigDecimal BigD = new BigDecimal(String.valueOf( Data));
		//BigDecimal mul =  BigC.multiply(BigD);
		//double double_bigNum = mul.doubleValue(); //BigIntger -> double	
		String result;	
		result = String.format("%.14e",data);
		System.out.println(result);
		return result;
	}
	
	private void calculate()
	{
		if(textPanel.blankSpace.getText().contains("+")) temp = calculation(temp, number, "+");
		else if(textPanel.blankSpace.getText().contains("-")) temp = calculation(temp, number, "-");
		else if(textPanel.blankSpace.getText().contains("x")) temp = calculation(temp, number, "x");
		else if(textPanel.blankSpace.getText().contains("÷")) temp = calculation(temp, number, "÷");
	}
	
	private void exceptionPrint()
	{
		String errorMessage = textPanel.inputSpace.getText();
		switch(errorMessage) {
		case "NaN" : textPanel.inputSpace.setText("정의되지 않은 결과입니다."); break;
		case "Infinity" : textPanel.inputSpace.setText("0으로 나눌 수 없습니다."); break;
		}
		
		if(math.equals("÷") && record.equals("0")) {
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
	

	
	public String calculation(String temp, String number, String operator) { // 결과 
		BigDecimal leftNumber = new BigDecimal(temp);
		BigDecimal rightNumber = new BigDecimal(number);
		BigDecimal result = new BigDecimal("0");
		
		switch(operator) {  // 저장했던 연산
		case "+": result = leftNumber.add(rightNumber);break;
		case "-": result = leftNumber.subtract(rightNumber);break;
		case "÷": result = leftNumber.divide(rightNumber);break;
		case "x": result = leftNumber.multiply(rightNumber);break;				
		}
		return result.toString();
	}
	
}
	
	
	
	




