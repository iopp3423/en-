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
	private int length; // 길이 
	private int limit; // 숫자 입력 제한 
	private int dotCount = Constants.ZERO;
	private String inputRecord;
	private String Record;
	private String newInput;

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
		}
	 
	};
		
	private void Delete() // C
	{
		if(text == "←") // 백스페이스 
		{
			 if (length == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
             {
				 textPanel.inputSpace.setText("0");
             }
			 else if(length != Constants.ONE) // 백스페이스 
			 {
				 inputRecord = textPanel.inputSpace.getText().substring(Constants.ZERO,length-Constants.ONE); // 문자열자르기
				 textPanel.inputSpace.setText(inputRecord);
			 }

		}
	}
	
	private void number()
	{
		
		if(text == "0")
		{
			if (length == Constants.ONE && textPanel.inputSpace.getText() == "0")   //글자가 없을 때 백스페이스 누르면 0으로 초기
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
			
			/*
			dotCount++;
			
			if(dotCount != 4 && limit <= 19) {
				newInput = inputRecord+Record; // 입력			 
				textPanel.inputSpace.setText(newInput);
			}
			
			else if (dotCount == 4 && limit <= 19){
				dotCount = Constants.ZERO;
				newInput = inputRecord+","+Record; // 입력
				textPanel.inputSpace.setText(newInput);
			}
			*/
									
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
	
	private void inputNumber()
	{
		if(textPanel.inputSpace.getText() == "0") textPanel.inputSpace.setText(""); // 제일 처음 입력 
			
		inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
		Record = text;// 키보드 입력한 순간 값  	
		
		if(limit<Constants.LIMIT_INPUT)
		{
			newInput = inputRecord+Record; // 입력			 
			textPanel.inputSpace.setText(newInput);
		}
		limit = newInput.length();
	}
	
	
	private void Reset() // 초기화 
	{
		if(text == "C")
		{
			for(int index=length; index>Constants.ZERO; index--)
			{
				if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
	             {
					 textPanel.inputSpace.setText("0");
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
				length = newInput.length();
				textPanel.inputSpace.setText(newInput);	
				dotCount++;
				
				
				/*
				inputRecord = textPanel.inputSpace.getText(); // 키패드 화면에 있던 값 
				Record = text;// 키보드 입력한 순간 값  	
				
				if(limit<Constants.LIMIT_INPUT)
				{
					newInput = inputRecord+Record; // 입력			 
					textPanel.inputSpace.setText(newInput);
				}
				limit = newInput.length();
				*/
			}	

			
		}
	}
	
	
	
}


