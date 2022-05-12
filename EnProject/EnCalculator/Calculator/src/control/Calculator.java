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
	private int length;

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
			text = (e.getActionCommand());
			//System.out.println(e.getActionCommand()); // 키 값 누른 거 출력 나중에 지우
			length = textPanel.inputSpace.getText().length(); // 입력패드의 길이 가져오기
			Delete();	// 백스페이스 
			InputNumber(); // 키패
			Reset();// 초기화 
		}
	 
	};
		
	private void Delete()
	{
		if(text == "←") // 백스페이스 
		{
			System.out.println(text);
			 if (length == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
             {
				 textPanel.inputSpace.setText("0");
             }
			 else if(length != Constants.ONE) // 백스페이스 
			 {
				 String inputRecord = textPanel.inputSpace.getText().substring(length-Constants.ONE, length); // 문자열자르기
				 textPanel.inputSpace.setText(inputRecord);
			 }
		}
	}
	
	private void InputNumber()
	{
		
		if(text == "0")
		{
			if(length != Constants.ONE)
			{
				System.out.println(text);	
				textPanel.inputSpace.setText("0");
			}
		}
		if(text == "1")
		{
			System.out.println(text);
			System.out.println(length);
			if(textPanel.inputSpace.getText() == "0") textPanel.inputSpace.setText(""); // 제일 처음 입력 
			
			String inputRecord = textPanel.inputSpace.getText();
			String Record = text;
			String newInput = inputRecord + Record;
			int N = newInput.length();
			
			//newInput.setText(text);
			
			System.out.println(inputRecord);
			System.out.println(Record );
			System.out.println(newInput);
			System.out.println(N);
			textPanel.inputSpace.setText(newInput);				
		}
		
		if(text == "2")
		{
			System.out.println(text);
			textPanel.inputSpace.setText("2");
		}
		if(text == "3")
		{
			System.out.println(text);
			textPanel.inputSpace.setText("3");
		}
		if(text == "4")
		{
			System.out.println(text);
			textPanel.inputSpace.setText("4");
		}
		if(text == "5")
		{
			System.out.println(text);
			textPanel.inputSpace.setText("5");
		}
		if(text == "6")
		{
			System.out.println(text);
			textPanel.inputSpace.setText("6");
		}
		if(text == "7")
		{
			System.out.println(text);
			textPanel.inputSpace.setText("7");
		}
		if(text == "8")
		{
			System.out.println(text);
			textPanel.inputSpace.setText("8");
		}
		if(text == "9")
		{
			System.out.println(text);
			textPanel.inputSpace.setText("9");
		}
	}
	
	
	private void Reset() // 초기
	{
		if(text == "C")
		{
			System.out.println(text);
			for(int index=length; index>Constants.ZERO;index--)
			{
				if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
	             {
					 textPanel.inputSpace.setText("0");
	             }
				
				String inputRecord = textPanel.inputSpace.getText().substring(index-Constants.ONE, index); // 문자열자르
				textPanel.inputSpace.setText(inputRecord);
			}
		}
	}
}


