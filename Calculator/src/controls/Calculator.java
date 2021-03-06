package controls;
import java.awt.Color;
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
import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.math.BigDecimal;

import javax.swing.JButton;
import javax.swing.JComponent;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;

import java.math.BigInteger;
import java.math.RoundingMode;
import java.text.DecimalFormat;



public class Calculator{

	private PrintCalculator printCalculator;
	private CalculatorPanel calculatorPanel;
	private JScrollPane scrollPane;
	private TextPanel textPanel;
	private RecordPanel recordPanel;
	private OperatorData Data;
	private supportText support;
	
	private String text;
	private String record = "";
	private String number = "0";
	private int pluscount = Constants.RESET;
	private int buttonNumber = Constants.RESET;

	public Calculator(PrintCalculator printCalculator)
	{	
		this.printCalculator = printCalculator;
		calculatorPanel = new CalculatorPanel(actionlistener, keyAdapter);
		recordPanel = new RecordPanel(printRecord);
		scrollPane = new JScrollPane(recordPanel);
		textPanel = new TextPanel(calculatorPanel, scrollPane, printCalculator, recordPanel);  //입력패드 생성 textPanel = new TextPanel(calculatorPanel, recordPanel);
		Data = new OperatorData();
		support = new supportText(textPanel, Data);
		callCalculator();// 계산기 출력 
	}
	
	public void callCalculator() // 계산기 출력 
	{
		printCalculator.openCalculator(calculatorPanel, textPanel, recordPanel, scrollPane); // 계산기 출력	
	}
	
	
	ActionListener printRecord = new ActionListener(){ // 누른 키패드 가져오기
		public void actionPerformed(ActionEvent e) {			
			String getRecode = (e.getActionCommand()); // 입력한  값 가져오기 	
			String[] leftNumber = new String[1];
			String[] recordList = getRecode.split(" ");
			textPanel.blankSpace.setText(recordList[1]);
			textPanel.inputSpace.setText(recordList[3]);
			recordList[1] = recordList[1].replace("=", "");
			
			if(recordList[1].contains("-")) {
				leftNumber = recordList[1].split("-");			
			}
			if(recordList[1].contains("+")) {
				leftNumber = recordList[1].split("+");
			}	
			if(recordList[1].contains("x")) {
				leftNumber = recordList[1].split("x");
			}
			if(recordList[1].contains("÷")) {
				leftNumber = recordList[1].split("÷");
			}
			
			recordList[3] = recordList[3].replace(",", "");
			
			Data.setTemp(leftNumber[0]); // 왼쪽값 저장 
			number = leftNumber[1]; // 오른쪽 값 저장 
			Data.setResult(recordList[3]); // 결과값 저장 
			
		}
		
	};

	ActionListener actionlistener = new ActionListener(){ // 누른 키패드 가져오기
		public void actionPerformed(ActionEvent e) {	
			text = (e.getActionCommand()); // 입력한  값 가져오기 	
			if(recordPanel.button[Constants.RESET].getText().contains("아직")) buttonNumber = Constants.RESET;
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
			support.adjustFontSize();
		}
		
	};
	
	KeyAdapter keyAdapter = new KeyAdapter() {
		public void keyPressed(KeyEvent e) {
			System.out.println(e.getKeyCode());	
			if(recordPanel.button[Constants.RESET].getText().contains("아직")) buttonNumber = Constants.RESET;
			
			if(e.getKeyCode() == 56 && e.isShiftDown()) {
				text = "x";
				combineCalculate();
				return;
			}
			if(e.getKeyCode() == 61 && e.isShiftDown()) {
				text = "+";
				combineCalculate();
				return;
			}
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
			case 61 : text = "="; result(); break;
			case 107 : text = "+"; combineCalculate(); break;
			case 109 : text = "-"; combineCalculate(); break;
			case 111 : text = "÷"; combineCalculate(); break;
			case 47 : text = "÷"; combineCalculate(); break;
			case 106 : text = "x"; combineCalculate();  break;
			case 8: text = "\u232B"; delete(); break;
			case 27: text = "C"; reset(); break;
			}
			support.adjustFontSize();		
		}
	};
		
	private void delete() 
	{	
		
		String inputRecord;
	
		if(Data.getFormula() == "=" && !Data.getOperator().equals("=")) { /// 계산하고 바로 지울 때 중간값만 지우기 
			 for(int index=textPanel.blankSpace.getText().length(); index>Constants.RESET; index--)
				{
					if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
		             {
						Data.setDotCount(Constants.RESET);
						 textPanel.blankSpace.setText(support.setComma(" ")); // 중간 값 
						 number = "0";
						 pluscount = Constants.RESET;
		             }
				}
		 }	
		else if(Data.getFormula() == "=" && Data.getOperator().equals("=")) { /// 22 = 하고 백스페이스 하면 변경사항 없
			//
		 }	
		
		 else if (textPanel.inputSpace.getText().length() == Constants.ONE)   //글자수가 1일 때  백스페이스 누르면 0으로 초기
         {
			 Data.setDotCount(Constants.RESET);
			 textPanel.inputSpace.setText("0");
			 number = "0";
			 record = "";
         }
		
		 else if(textPanel.inputSpace.getText().length() != Constants.ONE) //글자수 1 아니면 
		 {
			 inputRecord = record.substring(Constants.RESET,record.length()-Constants.ONE); // 문자열자르기
			 textPanel.inputSpace.setText(support.setComma(inputRecord));
			 
			 number = inputRecord; //지운만큼 넘버값 줄이기 
			 record = inputRecord;
		 }
		 

	}
	
	
	private void inputZero()
	{
		int limit = record.length();
		
		Data.setNegateOperator("");
		if(Data.getResult().equals("0") && textPanel.blankSpace.getText().contains("negate")) {
			textPanel.blankSpace.setText(support.changeNumber(Data.getTemp()) +  Data.getOperator()); // 중앙 화면
		}
		
		if(Data.getFormula().equals("=")) { // 계산하고 바로 숫자패드 입력 시초기
			reset();
		}
		
		if(text.equals("0"))
		{
			if(textPanel.inputSpace.getText() == "0") {
				textPanel.inputSpace.setText("0");
			}
			else if(limit<Constants.LIMIT_INPUT)
			{				 		
				record += text;// 키보드 입력
				number = record; //// 넘버에 입력값 넣어주기
				textPanel.inputSpace.setText(support.setComma(record));	
			}
		}
	}
	
	
	private void inputNumber() // 입력 
	{		
		int limit = record.length();
		
		Data.setNegateOperator("");	
		pluscount = Constants.RESET;
				
		if(Data.getResult().equals("0") && textPanel.blankSpace.getText().contains("negate")) {
			textPanel.blankSpace.setText(support.changeNumber(Data.getTemp()) +  Data.getOperator()); // 중앙 화면
			pluscount = Constants.RESET;
			System.out.println("count=" + pluscount);
		}
		else if(textPanel.blankSpace.getText().contains("negate")) {
			pluscount = Constants.RESET;
		}
		
		if(limit<Constants.LIMIT_INPUT) 
		{	
			if(Data.getFormula().equals("=")) { // 계산하고 바로 숫자패드 입력 시초기
				reset();
			}
			
			record += text;// 입력
			if(pluscount % Constants.EVEN_CHECK == Constants.Odd_CHECK) {
				textPanel.inputSpace.setText("-" + support.setComma(record)); //pluscount 홀수면 - 붙혀서 출력하
				number = "-" + record; //// 넘버에 입력값 넣어주기
			}
			else if(textPanel.inputSpace.getText().equals("0")){ // 0밖에 없으
				textPanel.inputSpace.setText("");  // 0 없애기  
				textPanel.inputSpace.setText(support.setComma(record));
				number = record; //// 넘버에 입력값 넣어주기
			}
			else {
				textPanel.inputSpace.setText(support.setComma(record));
				number = record; //// 넘버에 입력값 넣어주기
			}	
			
		}
	}
	
	
	private void reset() // C
	{
		Data.setcheckingNegate(false);
		Data.setNegate("");
		number = "0";
		pluscount = Constants.RESET;
		record = "";
		Data.setOperator("=");
		Data.setFormula("");
		Data.setDotCount(Constants.RESET);
		Data.setResult("0");
		Data.setTemp("0");
		Data.setNegateOperator("");
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
		Data.setDotCount(Constants.RESET);
		Data.setNegate("");
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
		pluscount++;
		
		if(pluscount % Constants.EVEN_CHECK == Constants.Odd_CHECK && !textPanel.inputSpace.getText().contains("-")) { // 짝수면 플러스, 홀수면 마이너스 
			
			if(record == "") textPanel.inputSpace.setText("-" + (Data.getTemp())); // 짝수 이면서 2 -> 사칙연산 -> +-눌렀을 
			else if (record != "") textPanel.inputSpace.setText("-" + support.setComma(record)); //그냥 +-
			number = "-" + number;
		}
		
		
		else {
			if(record == "") textPanel.inputSpace.setText(support.setComma(Data.getTemp()));// 홀수이면서 2 -> 사칙연산 -> +-눌렀을 
			else if (record != "") textPanel.inputSpace.setText(support.setComma(record));//그냥 +-
			number = number.replace("-", "");
			}	
		
		printNegate();
		
			if(textPanel.inputSpace.getText().contains("--")) {
				textPanel.inputSpace.setText(textPanel.inputSpace.getText().replace("--",""));
				number = number.replace("--", "-");
			}
		}
		
	}
	
	
	private void inputDot() // 소수점 
	{
		Data.setNegateOperator("");
		if(Data.getResult().equals("0") && textPanel.blankSpace.getText().contains("negate")) {
			textPanel.blankSpace.setText(support.changeNumber(Data.getTemp()) +  Data.getOperator()); // 중앙 화면
		}
		if(Data.getFormula().equals("=")) { // 계산하고 바로 숫자패드 입력 시초기
			reset();
		}
		if(textPanel.inputSpace.getText().equals("0")) { // 0일 때 
			record = "0" + text;// 키보드 입력한 값	
			textPanel.inputSpace.setText(support.setComma(record));
			Data.setDotCount(Constants.ONE);	
		}
		
		if (Data.getDotCount() == Constants.RESET && !(textPanel.inputSpace.getText().equals("0"))) { // 0제외 
			record += text;// 키보드 입력한 값	
			
			textPanel.inputSpace.setText(record);
			Data.setDotCount(Constants.ONE);
		}
			
		if(Data.getResult().equals("0") && record.equals(".")) { // 2.5 - negate. -> 0
			textPanel.inputSpace.setText(Data.getResult() + record);
			Data.setDotCount(Constants.ONE);	
		}
		
		if(Data.getResult() == "0" && record.equals(".")) { // 2.5 - negate. -> 0
			textPanel.inputSpace.setText(Data.getResult() + record);
			Data.setDotCount(Constants.ONE);	
		}	
	}
	
	
	private void result(){ // 결
		
		Data.setNegateOperator(text);
		boolean isnegate;
		
		if(textPanel.blankSpace.getText().contains("negate")) isnegate = true;
		else isnegate = false;
		
		if(number == "0") number = Data.getTemp(); // 2X4=, 2+5= 형식 처리 
		if(textPanel.inputSpace.getText().contains("정") || textPanel.inputSpace.getText().contains("나눌")) reset();
		
		printResult();

		if(!textPanel.inputSpace.getText().contains("나눌") && !textPanel.inputSpace.getText().contains("정") && isnegate) { // negate 로그 남기기 
		recordPanel.button[buttonNumber++].setText("<HTML> "+ textPanel.blankSpace.getText() +" <br> "+ textPanel.inputSpace.getText()); 
		}
		
		
		
		if(!Data.getOperator().equals(text)) { // 2 x 5 = 10 
		textPanel.blankSpace.setText(support.changeNumber(Data.getTemp()) + Data.getOperator() + support.changeNumber(number) + text);
		textPanel.inputSpace.setText(support.setComma(support.changeNumber(Data.getResult())));
		
		if(Data.getNegate().contains("negate") && Data.getcheckingNegate() == true) { // 9 * 5 = negate + 5 출력 
			textPanel.blankSpace.setText(Data.getNegate() + Data.getOperator() + support.changeNumber(number) + text);
			textPanel.inputSpace.setText(support.setComma(support.changeNumber(Data.getResult())));
		}
		
		if(textPanel.inputSpace.getText().contains("0으")) { //0으로 나눌 수 없습니다. 
			textPanel.blankSpace.setText(support.changeNumber(Data.getTemp()) + Data.getOperator());
		}
		
		if(!textPanel.inputSpace.getText().contains("나눌") && !textPanel.inputSpace.getText().contains("정") && !isnegate) // negate 없을 때 로그 남기
		recordPanel.button[buttonNumber++].setText("<HTML> "+ textPanel.blankSpace.getText() +" <br> "+ textPanel.inputSpace.getText()); 
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////
				
		else if(Data.getOperator().equals(text)){//.equals(text)) { // 0.1 =====
			textPanel.blankSpace.setText(number+ text);
			textPanel.inputSpace.setText(support.setComma(number));
		
			if(Double.parseDouble(number) % Constants.CHECK_DECIMAL == Constants.RESET) { // 3.0 = 입력시 정수로 출력 
				textPanel.blankSpace.setText(support.deleteDotZeroNumber(number)+text);
				textPanel.inputSpace.setText(support.setComma(support.deleteDotZeroNumber(number)));
			}
			recordPanel.button[buttonNumber++].setText("<HTML> "+ textPanel.blankSpace.getText() +" <br> "+ textPanel.inputSpace.getText()); 
		}
		/////////////////////////////////////////////////////////////////////////////////////////

		if(buttonNumber == 20) buttonNumber = Constants.RESET;		
		support.exceptionPrint(); // 예외 문
		support.adjustFontSize(); // 사이즈 조
		Data.setFormula("=");
	}
	
	
	private void printResult() // 결과값 출력(중앙 출력)
	{
		if(!Data.getFormula().equals("=")) { // 2x4 = 8 
			if(textPanel.inputSpace.getText().equals("0.")) number = "0";
			
			if(Data.getResult().equals("0")) Data.setResult(Data.getTemp()); //원래 없었고 밑에 Data.getTemp()였음 참
			
			switch(Data.getOperator()) {
			case "+" : Data.setResult(support.calculate(Data.getResult(), number, "+")); break;
			case "-" : Data.setResult(support.calculate(Data.getResult(), number, "-")); break;
			case "x" : Data.setResult(support.calculate(Data.getResult(), number, "x")); break;
			case "÷" : Data.setResult(support.calculate(Data.getResult(), number, "÷")); break;
			}
		}
		
		if(Data.getFormula().equals("=")) { //계산 후 바로 = 이 눌리면 
			textPanel.blankSpace.setText(support.changeNumber(Data.getResult()) + Data.getOperator() + support.changeNumber(number) + text);
			
			switch(Data.getOperator()) { //  원래 로직 Data.getTemp()였는데 바꿈 참고 
			case "+" : Data.setResult(support.calculate(Data.getResult(), number, "+")); break;
			case "-" : Data.setResult(support.calculate(Data.getResult(), number, "-")); break;
			case "x" : Data.setResult(support.calculate(Data.getResult(), number, "x"));break;
			case "÷" : Data.setResult(support.calculate(Data.getResult(), number, "÷")); break;
			}
			textPanel.inputSpace.setText(support.setComma(support.changeNumber(Data.getResult())));// 결과값 출력
		}
		support.exceptionPrint();
	}
	
	
	private void combineCalculate() //사칙연산 안에 계산 함수들 묶는용
	{
		if(textPanel.blankSpace.getText().equals(" ")) Data.setTemp(number);
		Data.setNegateOperator(text);
		moveCalculate();
		setCalculate();
		printCalculate();
	}
	
	
	private void moveCalculate()
	{
		if(textPanel.blankSpace.getText().contains("+")) Data.setTemp(support.calculate(Data.getTemp(), number, "+"));
		else if(textPanel.blankSpace.getText().contains("x")) Data.setTemp(support.calculate(Data.getTemp(), number, "x"));
		else if(textPanel.blankSpace.getText().contains("÷")) Data.setTemp(support.calculate(Data.getTemp(), number, "÷"));
		else if(textPanel.blankSpace.getText().contains("-"))Data.setTemp(support.calculate(Data.getTemp(), number, "-"));
	}
	
	private void printCalculate() // 화면에 값 출력 
	{
		int plusMinus = pluscount % Constants.EVEN_CHECK;
		
		if(textPanel.blankSpace.getText().contains("-") || textPanel.blankSpace.getText().contains("+") || textPanel.blankSpace.getText().contains("x") || textPanel.blankSpace.getText().contains("÷")) {
			if(record.equals(".")) record = "0"; // 33 + . + -> 기록에  33 + . = 33 => 33 + 0 = 으로 수정 
			if(buttonNumber == 20) buttonNumber = Constants.RESET; // 로그초기
			recordPanel.button[buttonNumber++].setText("<HTML> "+ textPanel.blankSpace.getText()+ record+ "=" + " <br> "+ Data.getTemp()); // 로그 남기기
		}
		
		
		if(textPanel.blankSpace.getText().contains("negate") && Data.getFormula().equals("=")) {
			textPanel.blankSpace.setText(Data.getNegate() + text);
			
			Data.setcheckingNegate(true);
				
			if(plusMinus == Constants.RESET) { 		
				Data.setResult(Data.getResult().replace("-","")); 
				System.out.println("Result2= " + Data.getResult());
			}
			else if(plusMinus == Constants.ONE) { 
				Data.setResult("-" + Data.getResult());
				textPanel.inputSpace.setText(support.setComma(Data.getResult())); // 입력화면
			}
			
		}
		
		else {
			textPanel.blankSpace.setText(support.changeNumber(Data.getTemp()) +  text); // 중앙 화면
			textPanel.inputSpace.setText(support.setComma(support.changeNumber(Data.getTemp()))); // 입력화면 	
		}

		support.adjustFontSize(); // 사이즈 조절 
		support.exceptionPrint();
		record=""; // 입력값 초기화 
		Data.setFormula("");
	}
	
	
	private void setCalculate() // 수식에 들어올 때 세팅 
	{
		//if(Data.getTemp().equals(""))Data.setTemp("0"); // 계산기 입력 없을 때 연산자 누르면 널값이 아닌 0이 올라감 
		number = "0"; // number 초기화 
		Data.setDotCount(Constants.RESET);	
		Data.setOperator(text); // 부호 넣어주기 
	}
	
	
	public void printNegate() {
		if(Data.getNegateOperator() != "") {
			int plusMinus = pluscount % Constants.EVEN_CHECK;
			
			if(!textPanel.blankSpace.getText().contains("=") && Data.getNegateOperator() != "" && !textPanel.blankSpace.getText().contains("negate")) { // 처음 negate 입력 
				Data.setNegate("negate(" + Data.getTemp() + ")"); // 제일 처음에 negate 저장
				Data.setNegateCount(Constants.RESET);
			}
			if(textPanel.blankSpace.getText().contains("=") && Data.getNegateOperator() != "" && !textPanel.blankSpace.getText().contains("negate")) { // 처음 negate 입력 
				Data.setNegate("negate(" + Data.getResult() + ")"); // 제일 처음에 negate 저장
				Data.setNegateCount(Constants.ONE);
			}
			
			if(Data.getNegateCount() == Constants.RESET) { // 2 + -> negate
				textPanel.blankSpace.setText(Data.getTemp() +  Data.getNegateOperator() + Data.getNegate()); // 중앙 화면
				switch(plusMinus) {			
				case 0:number = Data.getTemp().replace("-",""); break;
				case 1:number = "-" + Data.getTemp(); break;
				}
				Data.setNegate("negate(" + Data.getNegate() + ")"); // negate 출
			}
			
			else if(Data.getNegateCount() == Constants.ONE) {	// 2 + 4 = 6 -> negate
				textPanel.blankSpace.setText(Data.getNegate()); // 중앙 화면
				switch(plusMinus) {
				case 0: number = Data.getResult().replace("-","");break;
				case 1: number = "-" + Data.getResult(); break;
				}
				Data.setNegate("negate(" + Data.getNegate() + ")"); // negate 출
			}
			
			textPanel.inputSpace.setText(support.setComma(number));
		}
	}
	
}
	
	
	
	




