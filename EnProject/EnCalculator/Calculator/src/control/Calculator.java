package control;
import java.awt.event.ActionEvent;

import Utility.Constants;
import model.CalculationData;
import model.LogData;
import view.CalculatorPanel;
import view.PrintCalculator;
import view.TextPanel;

import java.awt.event.ActionListener;




public class Calculator{

	public CalculationData calculationData;
	public LogData logData;
	private PrintCalculator printCalculator;
	private CalculatorPanel calculatorPanel;
	private TextPanel textPanel;
	private String text;
	private String inputRecord;
	private String Record = "";
	private String newInput;
	private String math; 
	private String formula;
	private double result = 0;
	private double temp = 0;
	private int length; // 길이 
	private int inputLength;
	private int limit; // 숫자 입력 제한 
	private int dotCount = Constants.ZERO;
	private double number = Constants.ZERO;

	
	public Calculator(CalculationData calculationData, LogData logData, PrintCalculator printCalculator)
	{
		this.calculationData = calculationData;
		this.logData = logData;
		this.printCalculator = printCalculator;
		calculatorPanel = new CalculatorPanel(actionlistener);// 키패드 패널생성 
		textPanel = new TextPanel();  //입력패드 생성 
		CallCalculator();// 계산기 출력 
	}
	
	
	public void CallCalculator() // 계산기 출력 
	{
		printCalculator.GetCalculator(calculatorPanel, textPanel); // 계산기 출력	
	}
	
	
		
	ActionListener actionlistener = new ActionListener(){ // 누른 키패드 가져오기 
		public void actionPerformed(ActionEvent e) {									
			text = (e.getActionCommand()); // 입력한  값 가져오기 
			length = textPanel.inputSpace.getText().length(); // 입력패드의 길이 가져오기			
			
			
			Delete();	// 백스페이스 
			number(); // 키패
			Reset();// 초기화 
			inputDot(); // 소수점 
			division(); // 나누
			multyfly(); // 곱하
			minus(); // 빼기 
			plus(); // 더하기 
			result(); // 결과 
			
		}
	 
	};
		
	private void Delete() 
	{
		if(text == "\u232B") // 백스페이스 
		{
		
			if(formula == "=") { /// 계산하고 바로 지울 때 중간값만 지우기 
				 for(int index=length; index>Constants.ZERO; index--)
					{
						if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
			             {
							 textPanel.blankSpace.setText(" "); // 중간 값 
							 number = 0;
			             }
					}
			 }
			 
			
			 else if (length == Constants.ONE)   //글자수가 1일 때  백스페이스 누르면 0으로 초기
             {
				 textPanel.inputSpace.setText("0");
				 number = 0;
				 Record = "0";
				 System.out.println(number);
             }
			
			 if(length != Constants.ONE) //글자수 1 아니면 
			 {
				 inputRecord = Record.substring(Constants.ZERO,length-Constants.ONE); // 문자열자르기
				 textPanel.inputSpace.setText(inputRecord);
				 
				 number = Double.parseDouble(inputRecord); //지운만큼 넘버값 줄이기 
				 Record = inputRecord;
				 System.out.println(number);
			 }

		}
	}
	
	private void number()
	{
		
		if(text == "0")
		{
			inputNumber();	
			
		}
		if(text == "1")
		{
			inputNumber();									
		}
		
		if(text == "2")
		{
			inputNumber();
		}
		if(text == "3")
		{
			inputNumber();
		}
		if(text == "4")
		{
			inputNumber();
		}
		if(text == "5")
		{
			inputNumber();
		}
		if(text == "6")
		{
			inputNumber();
		}
		if(text == "7")
		{
			inputNumber();
		}
		if(text == "8")
		{
			inputNumber();
		}
		if(text == "9")
		{
			inputNumber();
		}
	}
	
	
	private void inputNumber() // 키보드 입력 
	{		
		if(length == Constants.ONE && text == "0") {
			textPanel.inputSpace.setText("0");
		}
			
		else if(limit<Constants.LIMIT_INPUT)
		{				 		
			Record += text;// 키보드 입력
			number = Double.parseDouble(Record); //// 넘버에 입력값 넣어주기
			textPanel.inputSpace.setText(Record);
			
		}
		limit = Record.length();
	}
	
	
	private void Reset() // C
	{
		if(text == "C")
		{
			Record = "";
			math = "";
			formula = "";
			dotCount=0;
			result = 0;
			temp = 0;
			for(int index=length; index>Constants.ZERO; index--)
			{
				if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
	             {
					 textPanel.inputSpace.setText("0");
					 textPanel.blankSpace.setText(" "); // 중간 값 
	             }
			}
		}
	}
	
	private void inputDot() // 소수점 
	{
		if(text==".")
		{
			
			if(dotCount == 0) {
				Record = text;// 키보드 입력한 값	
				textPanel.inputSpace.setText(textPanel.inputSpace.getText() + Record);					
				dotCount++;
				
			}	

			
		}
	}
	
	
	private void division() // 나누기 
	{
		if(text=="÷")
		{					
			//result += number;
			formula = ""; // "=" 초기
			math = text; // math 에 부호 넣어주
			temp += number; // temp 에 입력값 넣어주기 ex) 10, 111, 456
			number = 0; // number 초기화 
			Record=""; // 입력값 초기화 
				
			textPanel.blankSpace.setText((int)(temp) +  text); // 중앙 화면
			textPanel.inputSpace.setText(String.valueOf((int) temp)); // 입력화면 
			}
			//if(textPanel.blankSpace.getText() == "") textPanel.blankSpace.setText("0"); // 제일 처음 입력 	
		
			
	}
		
	private void multyfly() // 곱하기 
	{
		if(text=="x")
		{
			//result += number;
			formula = ""; // "=" 초기
			math = text; // math 에 부호 넣어주기 
			temp += number; // temp 에 입력값 넣어주기 ex) 10, 111, 456
			number = 0; // number 초기화 
			Record=""; // 입력값 초기화 
				
			textPanel.blankSpace.setText((int)(temp) +  text); // 중앙 화면
			textPanel.inputSpace.setText(String.valueOf((int) temp)); // 입력화면 
			}
			//if(textPanel.blankSpace.getText() == "") textPanel.blankSpace.setText("0"); // 제일 처음 입력 	
		
		
	}
	private void minus() // 빼기 
	{
		if(text=="-")
		{
			//result += number;
			formula = ""; // "=" 초기
			math = text; // math 에 부호 넣어주
			temp += number; // temp 에 입력값 넣어주기 ex) 10, 111, 456
			number = 0; // number 초기화 
			Record=""; // 입력값 초기화 
				
			textPanel.blankSpace.setText((int)(temp) +  text); // 중앙 화면
			textPanel.inputSpace.setText(String.valueOf((int) temp)); // 입력화면 
			}
			//if(textPanel.blankSpace.getText() == "") textPanel.blankSpace.setText("0"); // 제일 처음 입력 	
	}
	private void plus(){ // 더하기 
	
		if(text=="+")
		{
			//result += number;
			formula = ""; // "=" 초기
			math = text; // math 에 부호 넣어주
			temp += number; // temp 에 입력값 넣어주기 ex) 10, 111, 456
			number = 0; // number 초기화 
			Record=""; // 입력값 초기화 
				
			textPanel.blankSpace.setText((int)(temp) +  text); // 중앙 화면
			textPanel.inputSpace.setText(String.valueOf((int) temp)); // 입력화면 
			}
			//if(textPanel.blankSpace.getText() == "") textPanel.blankSpace.setText("0"); // 제일 처음 입력 	
	}
	
	
	private void result(){
				
		if(text == "=") {
			if(number == Constants.ZERO) number = temp; // 2X4=, 2+5= 형식 처리  
			
			if(math == "+") {
				//math = "";
				if(formula !="=") result = temp + number;
				else if(formula == "=") { //바로 = 이 눌리면 
					textPanel.blankSpace.setText(String.valueOf((int) result) + math + String.valueOf((int) number) + text);
					temp = result;
					result = result + number;
				}
			}
			else if(math == "-") {
				if(formula !="=") result = temp - number;
				else if(formula == "=") { //바로 = 이 눌리면 
					textPanel.blankSpace.setText(String.valueOf((int) result) + math + String.valueOf((int) number) + text);
					temp = result;
					result = result - number;
				}
			}
			else if(math == "÷") {
				if(formula !="=") result = temp / number;
				else if(formula == "=") { //바로 = 이 눌리면 
					textPanel.blankSpace.setText(String.valueOf((int) result) + math + String.valueOf((int) number) + text);
					temp = result;
					result = result / number;
				}
			}
			else if(math == "x") {
				if(formula !="=") result = temp * number;
				else if(formula == "=") { //바로 = 이 눌리면 
					textPanel.blankSpace.setText(String.valueOf((int) result) + math + String.valueOf((int) number) + text);
					temp = result;
					result = result * number;
				}
			}
			
		
			//if(textPanel.blankSpace.getText() != "" && textPanel.inputSpace.getText() != "") {
				if(result % 1.0 == 0) {
					if(formula != "=")textPanel.blankSpace.setText(String.valueOf((int) temp) + math + String.valueOf((int) number) + text );
					textPanel.inputSpace.setText(String.valueOf((int) result));
				}
				else {
					textPanel.blankSpace.setText(textPanel.blankSpace.getText() + textPanel.inputSpace.getText() + text );
					textPanel.inputSpace.setText(String.valueOf(result));
				}
		//	}
			formula = "=";
		}
		
	}
	
}


