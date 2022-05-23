package models;

import java.math.BigDecimal;
import java.text.DecimalFormat;

import Utility.Constants;

public class OperatorData {

	
	private String result = "0";
	private String temp = "0";
	private String operator = "=";
	private String formula = "";
	private String negateOperator = "";
	private String negate = "";
	private boolean checkingNegate = false;
	private int dotCount=Constants.RESET;
	private int negateCount = Constants.RESET; 
	
	public void setResult(String result) { // = 저
		this.result = result;
	}
	public String getResult() {
		return result;
	}
	public void setTemp(String temp) {
		this.temp = temp;
	}
	public String getTemp() {
		return temp;
	}
	public void setOperator(String operator) {
		this.operator = operator;
	}
	public String getOperator() {
		return operator;
	}
	public void setFormula(String formula) {
		this.formula = formula;
	}
	public String getFormula() {
		return formula;
	}
	public void setNegateOperator(String negate) {
		this.negateOperator = negate;
	}
	public String getNegateOperator() {
		return negateOperator;
	}
	public void setNegate(String negate) {
		this.negate = negate;
	}
	public String getNegate() {
		return negate;
	}
	public void setNegateCount(int negateCount) {
		this.negateCount = negateCount;
	}
	public int getNegateCount() {
		return negateCount;
	}
	public void setDotCount(int dotCount) {
		this.dotCount = dotCount;
	}
	public int getDotCount() {
		return dotCount;
	}
	public void setcheckingNegate(boolean checkingNegate) {
		this.checkingNegate = checkingNegate;
	}
	public boolean getcheckingNegate() {
		return checkingNegate;
	}
	
}
