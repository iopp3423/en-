package control;
import java.awt.event.ActionEvent;

import Utility.Constants;
import model.LogData;
import view.CalculatorPanel;
import view.PrintCalculator;
import view.TextPanel;

import java.awt.event.ActionListener;
import java.util.regex.Matcher;
import java.util.regex.Pattern;



public class Calculator{

	public LogData logData;
	private PrintCalculator printCalculator;
	private CalculatorPanel calculatorPanel;
	private TextPanel textPanel;
	private String text;
	private String inputRecord;
	private String Record = "";
	private String math; 
	private String formula;
	private String centerProperty;
	private double result = Constants.ZERO;
	private double temp = Constants.ZERO;
	private int length; // 길이 
	private int limit; // 숫자 입력 제한 
	private int dotCount = Constants.ZERO;
	private double number = Constants.ZERO;


	
	public Calculator(LogData logData, PrintCalculator printCalculator)
	{	
		this.logData = logData;
		this.printCalculator = printCalculator;
		textPanel = new TextPanel();  //입력패드 생성 
		calculatorPanel = new CalculatorPanel(actionlistener);
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
			centerProperty = textPanel.blankSpace.getText(); // 중간 화면 값 가져오기 
			delete();	// 백스페이스 
			inputnumber(); // 키패
			reset();// 초기화 
			resetPart(); // 부분초기화(CE)
			inputDot(); // 소수점 
			division(); // 나누
			multyfly(); // 곱하
			minus(); // 빼기 
			plus(); // 더하기 
			result(); // 결과 	
		}
	};
		
	private void delete() 
	{
		if(text == "\u232B") // 백스페이스 
		{
		
			if(formula == "=") { /// 계산하고 바로 지울 때 중간값만 지우기 
				 for(int index=length; index>Constants.ZERO; index--)
					{
						if (index == Constants.ONE)   //글자가 없을 때 백스페이스 누르면 0으로 초기
			             {
							 textPanel.blankSpace.setText(" "); // 중간 값 
							 number = Constants.ZERO;
			             }
					}
			 }
			 
			
			 else if (length == Constants.ONE)   //글자수가 1일 때  백스페이스 누르면 0으로 초기
             {
				 textPanel.inputSpace.setText("0");
				 number = Constants.ZERO;
				 Record = "0";
             }
			
			 if(length != Constants.ONE) //글자수 1 아니면 
			 {
				 inputRecord = Record.substring(Constants.ZERO,length-Constants.ONE); // 문자열자르기
				 textPanel.inputSpace.setText(inputRecord);
				 
				 number = Double.parseDouble(inputRecord); //지운만큼 넘버값 줄이기 
				 Record = inputRecord;
			 }

		}
	}
	
	private void inputnumber()
	{
		
		if(text == "0")
		{
			if(textPanel.inputSpace.getText() == "0") textPanel.inputSpace.setText("0");
			else if(limit<Constants.LIMIT_INPUT)
			{				 		
				Record += text;// 키보드 입력
				number = Double.parseDouble(Record); //// 넘버에 입력값 넣어주기
				textPanel.inputSpace.setText(setComma(Record));			
			}
			limit = Record.length();	
			
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
	
	
	private void inputNumber() // 키보드 입력 
	{		
		if(limit<Constants.LIMIT_INPUT)
		{				 		
			Record += text;// 키보드 입력
			number = Double.parseDouble(Record); //// 넘버에 입력값 넣어주기
			textPanel.inputSpace.setText(setComma(Record));	//, 찍기 
		}
		limit = Record.length();
	}
	
	
	private void reset() // C
	{
		if(text == "C")
		{
			Record = "";
			math = "";
			formula = "";
			dotCount=Constants.ZERO;
			result = Constants.ZERO;
			temp = Constants.ZERO;
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
	
	private void resetPart() // CE
	{
		if(text == "CE")
		{
			Record = "";
			number = Constants.ZERO;
			dotCount = Constants.ZERO;
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
			if(textPanel.inputSpace.getText() == "0" ) {
				Record += "0" + text;// 키보드 입력한 값	
				textPanel.inputSpace.setText(setComma(Record));
				dotCount++;		
				System.out.println(Record);
				System.out.println(setComma(Record));
				System.out.println(dotCount);
			}
			
			else if (dotCount == Constants.ZERO && textPanel.inputSpace.getText() != "0") {
				Record += text;// 키보드 입력한 값	
				textPanel.inputSpace.setText(setComma(Record));
				dotCount++;		
			}				
		}
	}
	
	
	private void division() // 나누기 
	{
		if(text=="÷")
		{				
			if(centerProperty == " ") temp = number;
			calculate();
			setCalculate();
			printCalculate();
		}
					
	}
		
	private void multyfly() // 곱하기 
	{
		
		if(text=="x")
		{
			if(centerProperty == " ") temp = number;
			calculate();
			setCalculate();
			printCalculate();
		}
		
	}
	private void minus() // 빼기 
	{
		if(text=="-")
		{
			if(centerProperty == " ") temp = number;
			calculate();
			setCalculate();
			printCalculate();
		}
				
	}
	private void plus(){ // 더하기 
	
		if(text=="+")
		{	
			if(centerProperty == " ") temp = number;
			calculate();
			setCalculate();
			printCalculate();
		}			
	}
	
	
	private void result(){ // 결
				
		if(text == "=") { // = 입력하면 
			if(number == Constants.ZERO) number = temp; // 2X4=, 2+5= 형식 처리  
			
			 printResult();
			
				if(result % Constants.CHECK_DECIMAL == Constants.ZERO) { // 정수형 출력 (중앙화면)
					if(formula != "=")textPanel.blankSpace.setText(String.valueOf((int) temp) + math + String.valueOf((int) number) + text );
					textPanel.inputSpace.setText(String.valueOf(String.valueOf((int)(result))));
				}
				else { // 더블형 출력 
					if(formula != "=")textPanel.blankSpace.setText(String.valueOf((double) temp) + math + String.valueOf((double) number) + text );
					textPanel.inputSpace.setText(String.valueOf((double) result));
				}

		formula = "=";// formula 가 = 이면 바로 = 눌러서 계산한 
		}
		
	}
	
	
	public void printResult() // 결과값 출력(중앙 출력)
	{
		if(formula != "=") {
			if(math == "+")result = temp + number;
			if(math == "-")result = temp - number;
			if(math == "x")result = temp * number;
			if(math == "÷")result = temp / number;
		}
		
		else if(formula == "=") { //바로 = 이 눌리면 
			if(result % Constants.CHECK_DECIMAL == Constants.ZERO)textPanel.blankSpace.setText(String.valueOf((int) result) + math + String.valueOf((int) number) + text);
			else if(result % Constants.CHECK_DECIMAL != Constants.ZERO)textPanel.blankSpace.setText(String.valueOf((double) result) + math + String.valueOf((double) number) + text);
			temp = result;
			if(math == "+") result = result + number;
			if(math == "-") result = result - number;
			if(math == "x") result = result * number;
			if(math == "÷") result = result / number;
		}
		
		
	}
	
	public void printCalculate() // 화면에 값 출력 
	{
		if(temp % Constants.CHECK_DECIMAL == Constants.ZERO) {
			textPanel.blankSpace.setText((int)(temp) +  text); // 중앙 화면
			textPanel.inputSpace.setText(setComma(String.valueOf(String.valueOf((int) temp)))); // 입력화면 
			}
			else {
				textPanel.blankSpace.setText((double)(temp) +  text); // 중앙 화면
				textPanel.inputSpace.setText(String.valueOf((double) temp)); // 입력화면 
			}
	}
	
	public void setCalculate() // 수식에 들어올 때 세
	{
		number = Constants.ZERO;; // number 초기화 
		Record=""; // 입력값 초기화 
		dotCount = Constants.ZERO;
		formula = ""; // "=" 초기
		math = text; // math 에 부호 넣어주
	}
	
	public void calculate()
	{
		if(textPanel.blankSpace.getText().contains("+"))temp += number;
		else if(textPanel.blankSpace.getText().contains("-"))temp -= number;
		else if(textPanel.blankSpace.getText().contains("x"))temp *= number;
		else if(textPanel.blankSpace.getText().contains("÷"))temp /= number;
	}
	
	public String setComma(String number) { // ,찍기 
        String changeResult = number; //출력할 결과를 저장할 변수
        Pattern pattern = Pattern.compile(Constants.decimal); //정규표현식 
        Matcher regexMatcher = pattern.matcher(number); 
        
        while(regexMatcher.find()) {                
        	changeResult = regexMatcher.replaceAll("$1,$2"); //치환 
                                
        	
            regexMatcher.reset(changeResult); 
        }        
        return changeResult;
    }

}


