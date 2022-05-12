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
	private double result = 0;
	private int length; // 길이 
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
		
	private void Delete() // C
	{
		if(text == "\u232B") // 백스페이스 
		{
			 if (length == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
             {
				 textPanel.inputSpace.setText("0");
             }
			 else if(length != Constants.ONE) // 백스페이스 
			 {
				 inputRecord = textPanel.inputSpace.getText().substring(Constants.ZERO,length-Constants.ONE); // 문자열자르기
				 textPanel.inputSpace.setText(inputRecord);
				 textPanel.blankSpace.setText(inputRecord); // 중간 값 
			 }

		}
	}
	
	private void number()
	{
		
		if(text == "0")
		{
			if (length == Constants.ONE && textPanel.inputSpace.getText() == "0")   
            {
				 textPanel.inputSpace.setText("0");
            }
			else
			{
				inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
				Record = text;// 키보드 입력한 순간 값  		
				if(limit<Constants.LIMIT_INPUT)
				{
					newInput = inputRecord+Record; // 입력			 
					textPanel.inputSpace.setText(newInput);
				}
				limit = newInput.length();
			}
			
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
		
		if(textPanel.inputSpace.getText() == "0") textPanel.inputSpace.setText(""); // 제일 처음 입력 
			
		inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
		Record += text;// 키보드 입력한 순간 값  	
		System.out.println("Record= " + Record);
		
		if(limit<Constants.LIMIT_INPUT) //&& textPanel.blankSpace.getText() == "+")
		{
			int length = textPanel.inputSpace.getText().length(); // 입력패드의 길이 가져오기	
			int subLength = textPanel.blankSpace.getText().length();
			
			//newInput = inputRecord+Record; // 입력			 
			textPanel.inputSpace.setText(Record);	
			number = Double.parseDouble(Record); //// 넘버에 입력값 넣어주기 
			
			//System.out.println("subLengtg = " + textPanel.blankSpace.getText().substring(Constants.ZERO,subLength-1));
			System.out.println("number=" +  number);
			
		}
		limit = Record.length();
	}
	
	
	private void Reset() // 초기화 
	{
		if(text == "C")
		{
			dotCount=0;
			for(int index=length; index>Constants.ZERO; index--)
			{
				if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
	             {
					 textPanel.inputSpace.setText("0");
					 textPanel.blankSpace.setText("0"); // 중간 값 
	             }
			}
		}
	}
	
	private void inputDot() // 소수점 
	{
		if(text==".")
		{
			
			if(dotCount == 0) {
				
				if(textPanel.inputSpace.getText() == "0") textPanel.inputSpace.setText("0"); // 제일 처음 입력 
				
				inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
				Record = text;// 키보드 입력한 순간 값
				newInput = inputRecord + Record;
				textPanel.inputSpace.setText(newInput);	
				dotCount++;
				
			}	

			
		}
	}
	
	
	private void division() // 나누기 
	{
		if(text=="÷")
		{
						
			if(textPanel.inputSpace.getText() == "0") textPanel.inputSpace.setText("0"); // 제일 처음 입력 
			
			inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
			Record = text;// 키보드 입력한 순간 값
			newInput = inputRecord + Record;
			textPanel.blankSpace.setText(newInput); // 중간 값 
			
			number = Double.parseDouble(inputRecord);
			result /= number;
		}
			
	}
		
	private void multyfly() // 곱하기 
	{
		if(text=="X")
		{
				
			if(textPanel.inputSpace.getText() == "0") textPanel.inputSpace.setText("0"); // 제일 처음 입력 
					
			inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
			Record = text;// 키보드 입력한 순간 값
			newInput = inputRecord + Record;
			textPanel.blankSpace.setText(newInput); // 중간 값 
			
			number = Double.parseDouble(inputRecord);
			result *= number;
				
		}
	}
	private void minus() // 빼기 
	{
		if(text=="-")
		{
		
			if(textPanel.inputSpace.getText() == "0") textPanel.inputSpace.setText("0"); // 제일 처음 입력 
			
			inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
			Record = text;// 키보드 입력한 순간 값
			newInput = inputRecord + Record;
			textPanel.blankSpace.setText(newInput); // 중간 값 
			
			number = Double.parseDouble(inputRecord);
			result -= number;
			
		}
	}
	private void plus(){ // 더하기 
	
		if(text=="+")
		{
			result += number;
			number = 0;
			Record="";
			if(textPanel.blankSpace.getText() == "") textPanel.blankSpace.setText("0"); // 제일 처음 입력 
			
			inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
			//Record = text;// 키보드 입력한 순간 값
			//newInput = inputRecord + Record;
			
			textPanel.blankSpace.setText(inputRecord + text); // 중간 값 
			

			System.out.println("result ="+ result);
			
		}
	}
	
	
	private void result(){
				
		if(text == "=") {
			
			System.out.println(result);

			if(textPanel.blankSpace.getText() != "" && textPanel.inputSpace.getText() != "" && textPanel.blankSpace.getText().contains(text) == false) {
				if(result % 1 == 0) {
					textPanel.blankSpace.setText(textPanel.blankSpace.getText() + textPanel.inputSpace.getText() + text);
					textPanel.inputSpace.setText(String.valueOf((int) result));
				}
				else {
					textPanel.blankSpace.setText(textPanel.blankSpace.getText() + textPanel.inputSpace.getText() + text);
					textPanel.inputSpace.setText(String.valueOf(result));
				}
			}
			result = 0;
		}
		
	}
	
}


