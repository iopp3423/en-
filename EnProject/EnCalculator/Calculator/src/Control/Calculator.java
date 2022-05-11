package Control;
import java.awt.BorderLayout;
import java.awt.event.ActionEvent;

import Model.CalculationData;
import Model.LogData;
import View.CalculatorPanel;
import View.PrintCalculator;

import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;

import javax.swing.JButton;

import Exception.Constants;
import java.lang.reflect.Method;



public class Calculator extends MouseAdapter{

	CalculationData calculationData;
	LogData logData;
	PrintCalculator printCalculator;
	

	public Calculator(CalculationData calculationData, LogData logData, PrintCalculator printCalculator)
	{
		this.calculationData = calculationData;
		this.logData = logData;
		this.printCalculator = printCalculator;
		CallCalculator();// 계산기 출력
	}
	
	
	
	public void CallCalculator()
	{
		CalculatorPanel calculatorPanel = new CalculatorPanel(listener);
		printCalculator.GetCalculator(calculatorPanel); // 계산기 출력	
		
		//addListener(listener);
	}
		
	ActionListener listener = new ActionListener(){ // 검색하기 
		public void actionPerformed(ActionEvent e) {									
			System.out.println(e.getActionCommand()); // 키 값 누른 거 가져
		}				
	};

	public void addListener(ActionListener listener ) {
		JButton button = new JButton();
		button.addActionListener(listener);		
		
	}
	
}


