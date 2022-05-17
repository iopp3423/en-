package models;

import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

import Utility.Constants;
import controls.Calculator;

public class inputData {
	
	/*
	public Calculator calculator;
	public ActionListener actionlistener;
	public KeyAdapter keyAdapter;
	
	
	public void dataProcess(Calculator calculator) {
		
		actionlistener = new ActionListener(){ // 누른 키패드 가져오기
			public void actionPerformed(ActionEvent e) {				
				calculator.text = (e.getActionCommand()); // 입력한  값 가져오기 
				calculator.length = calculator.textPanel.inputSpace.getText().length(); // 입력패드의 길이 가져오기			
				calculator.centerProperty = calculator.textPanel.blankSpace.getText(); // 중간 화면 값 가져오기 
				
				switch(calculator.text){
					case "\u232B": calculator.delete(); break;
					case "C" : calculator.reset(); break;
					case "CE": calculator.resetPart(); break;
					case "±" : calculator.changeSign(); break;
					case "." : calculator.inputDot(); break;
					case "=" : calculator.result(); break;
				}	
				calculator.inputnumber(); // 키패드 
				calculator.arithmaticCalculate();
				
				if(calculator.length>8 && calculator.length<21) calculator.textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.ZERO, 50-calculator.fontsize));  	// 마지
				calculator.fontsize+=Constants.ONE;
			}
			
		};
		
		
		
		keyAdapter = new KeyAdapter() {
			public void keyPressed(KeyEvent e) {
				//System.out.println(e.getKeyCode());
				calculator.length = calculator.textPanel.inputSpace.getText().length(); // 입력패드의 길이 가져오기			
				calculator.centerProperty = calculator.textPanel.blankSpace.getText(); // 중간 화면 값 가져오기 
				switch(e.getKeyCode()) {			
				case 48 : calculator.text = "0"; calculator.inputNumber(); break;
				case 49 : calculator.text = "1"; calculator.inputNumber(); break;
				case 50 : calculator.text = "2"; calculator.inputNumber(); break;
				case 51 : calculator.text = "3"; calculator.inputNumber(); break;
				case 52 : calculator.text = "4"; calculator.inputNumber(); break;
				case 53 : calculator.text = "5"; calculator.inputNumber(); break;
				case 54 : calculator.text = "6"; calculator.inputNumber(); break;
				case 55 : calculator.text = "7"; calculator.inputNumber(); break;
				case 56 : calculator.text = "8"; calculator.inputNumber(); break;
				case 57 : calculator.text = "9"; calculator.inputNumber(); break;
				case 107 : calculator.text = "+"; calculator.arithmaticCalculate(); break;
				case 109 : calculator.text = "-"; calculator.arithmaticCalculate(); break;
				case 10 : calculator.text = "="; calculator.result(); break;
				case 47 : calculator.text = "÷"; calculator.arithmaticCalculate(); break;
				case 106 : calculator.text = "x"; calculator.arithmaticCalculate();  break;
				case 8: calculator.text = "\u232B"; calculator.delete(); break;
				case 67: calculator.text = "C"; calculator.reset(); break;
				}
				
				if(calculator.length>8 && calculator.length<21) {
					calculator.textPanel.inputSpace.setFont(new Font("맑은 고딕",  Constants.ZERO, 50-calculator.fontsize));  	// 마지
				}
				calculator.fontsize+=Constants.ONE;
			}
		};
	}
	*/
}
