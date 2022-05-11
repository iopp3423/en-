package Control;
import java.awt.BorderLayout;
import java.awt.event.ActionEvent;

import Model.CalculationData;
import Model.LogData;
import View.CalculatorPanel;
import View.PrintCalculator;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import javax.swing.JButton;

import Exception.Constants;



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
		printCalculator.GetCalculator();
	}/*
		CalculatorPanel calculatorPanel = new CalculatorPanel(); // 숫자패드 생
		
		for(int index = 0; index<Constants.calculator; index++){
			
			calculatorPanel.button[index].addActionListener(new ActionListener(){ // 검색하기 
			public void actionPerformed(ActionEvent e) {									
					System.out.println(e.getActionCommand()); // 키 값 누른 거 가져
			}				
		});
	}
		printCalculator.frame.add(calculatorPanel, BorderLayout.SOUTH);
	
	}	
	*/
}


