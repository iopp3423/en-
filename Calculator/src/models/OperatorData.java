package models;

import java.math.BigDecimal;
import java.text.DecimalFormat;

public class OperatorData {

	
	private String result = "";
	private String temp = "";
	private String operator = "=";
	private String formula = "";
	
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
}
