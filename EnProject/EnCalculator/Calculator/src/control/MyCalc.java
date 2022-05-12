package control;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MyCalc extends JFrame {
	static JLabel label;
	static JLabel info;
	double result = 0;
	String math = "";
	double num = 0;
	String tostring = "";
	
	
	
	
	
	public MyCalc() {
		setTitle("내가 만든 계산 계산기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container MyCon = getContentPane();
		MyCon.setLayout(new BorderLayout(5, 5));
		MyCon.setBackground(Color.LIGHT_GRAY);
		
		//입력 값과 결과값이 출력되는 위 패널 생성 후 콘테이너에 추가
		UpPanel UP = new UpPanel();
		MyCon.add(UP, BorderLayout.EAST);
		//버튼을 넣을 아래 패널 생성 후 콘테이너에 추가
		DownPanel DP = new DownPanel();
		MyCon.add(DP, BorderLayout.SOUTH);
		
		setSize(350, 600);
		setVisible(true);
	}
	
	
	
	
	
	
	
	class UpPanel extends JPanel {
		public UpPanel() {
			setLayout(new GridLayout(3, 1));
			setBackground(Color.LIGHT_GRAY);
			info = new JLabel("");
			label = new JLabel("0");
			
			info.setFont(new Font("맑은 고딕", 0, 40));
			info.setForeground(Color.BLACK);
			info.setHorizontalAlignment(SwingConstants.RIGHT);
			
			label.setFont(new Font("맑은 고딕", Font.BOLD , 55));
			label.setForeground(Color.BLACK);
			label.setHorizontalAlignment(SwingConstants.RIGHT);
			
			add(info);
			add(label);
		}
	}
	
	
	
	
	
	
	class DownPanel extends JPanel{
		public DownPanel() {
			JButton[] bt = new JButton[20];
			setLayout(new GridLayout(5, 4, 5, 5));
			setBackground(Color.DARK_GRAY);
			
			bt[0] = new JButton("×");
			bt[1] = new JButton("÷");
			bt[2] = new JButton("AC");
			bt[3] = new JButton("C");

			bt[4] = new JButton("7");
			bt[5] = new JButton("8");
			bt[6] = new JButton("9");
			bt[7] = new JButton("√");
			
			bt[8] = new JButton("4");
			bt[9] = new JButton("5");
			bt[10] = new JButton("6");
			bt[11] = new JButton("-");
			
			bt[12] = new JButton("1");
			bt[13] = new JButton("2");
			bt[14] = new JButton("3");
			bt[15] = new JButton("+");
			
			bt[16] = new JButton("＾2");
			bt[17] = new JButton("0");
			bt[18] = new JButton(".");
			bt[19] = new JButton("=");
			
			for(int i = 0; i <= 19; i++) {
				bt[i].setPreferredSize(new Dimension(0, 65));
				bt[i].setFont(new Font("맑은 고딕", 0, 20));
				bt[i].setForeground(Color.BLACK);
				bt[i].setBackground(new Color(240, 240, 240));
				if(3 < i && i < 15 && i % 4 != 3) {
					bt[i].addActionListener(new ActionListener() {
						
						@Override
						public void actionPerformed(ActionEvent e) {
							JButton b = (JButton)e.getSource();
							if(label.getText() == "0") {
								label.setText("");
							}
							String labeltext = label.getText();
							String text = b.getText();
							String newtext = labeltext + text;
							int n = newtext.length();
							
							if(n <= 10) {
								label.setText(newtext);
							}
							if(info.getText().contains("=") == true) {
								info.setText("");
								label.setText(b.getText());
								result = 0;
								num = 0;
							}
						}
					});
				}else if(i == 17) {
					bt[i].addActionListener(new ActionListener() {
						
						@Override
						public void actionPerformed(ActionEvent e) {
							JButton b = (JButton)e.getSource();
							String labeltext = label.getText();
							String text = b.getText();
							String newtext = labeltext + text;
							if(labeltext == "0") {
								label.setText("0");
							}else {
								label.setText(newtext);
							}
							
						}
					});
				}
				
				
				else if(i == 19) {
					bt[i].setBackground(new Color(78, 197, 255));
					bt[i].addActionListener(new Result());
				}
				
				
				else if(i % 4 == 3 || i < 3 || 15 < i) {
					bt[i].setBackground(new Color(218, 218, 218));
					if(i == 2) {
							bt[i].addActionListener(new ActionListener() {
							
							@Override
							public void actionPerformed(ActionEvent e) {
								int n = label.getText().length();
								if(n >= 0) {
									label.setText("0");
									info.setText("");
								}
								result = 0;
							}
						});
					}
					
					
					else if(i == 3) {
						bt[i].addActionListener(new ActionListener() {
							
							@Override
							public void actionPerformed(ActionEvent e) {
								int n = label.getText().length();
								if(n > 0) {
									setBackSpace(getBackSpace().substring(0, getBackSpace().length() - 1));
								}
								if(label.getText() == "") {
									label.setText("0");
								}
							}
						});
					}
					
					else if(i == 18) {
						bt[i].addActionListener(new ActionListener() {
							
							@Override
							public void actionPerformed(ActionEvent e) {
								JButton b = (JButton)e.getSource();
								String labeltext = label.getText();
								String text = b.getText();
								String newtext = labeltext + text;
								int n = newtext.length();
								if(label.getText().contains(b.getText()) == false && n < 10) {
										label.setText(newtext);
								}
								}
						});
					}else {
						bt[i].addActionListener(new Result());
					}
				}
				add(bt[i]);
			}
		}		
	}
	
	
	
	
	
	public class Result implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			JButton b = (JButton)e.getSource();
			String labeltext = label.getText();
			String text = b.getText();
			String newtext = labeltext + text;
			int n = newtext.length();
			
			if(text != "＾2") {
				num = Double.parseDouble(label.getText().substring(0, n - 1));	
				System.out.println(num);
				System.out.println(text);
			}
			if(math == "+") {
				result += num;
				math = "";
			}else if(math == "-") {
				result -= num;
				math = "";
			}else if(math == "×") {
				result *= num;
				math = "";
			}else if(math == "÷") {
				result /= num;
				math = "";
			}
			if(math == "") {
				math = b.getText();			
			}
			
			if(info.getText() == "" && text != "＾2" && text != "=") {
				info.setText(newtext);
				result = num;
				label.setText("0");
			}
			
			else if(info.getText() != "" && text != "＾2" && text != "="){
				result = (Math.round(result*1000000000)/1000000000.0);
				if(result % 1 == 0) {
					info.setText((int) result + text);
					label.setText("0");
				}else {
					info.setText(result + text);
					label.setText("0");
				}
			}
			

			
			if(text == "=") {
				math = "";
				if(info.getText() != "" && label.getText() != "" && info.getText().contains(text) == false) {
					if(result % 1 == 0) {
						info.setText(info.getText() + label.getText() + text);
						label.setText(String.valueOf((int) result));
					}else {
						info.setText(info.getText() + label.getText() + text);
						label.setText(String.valueOf(result));
					}
				}
			}
		}
	}
	
	public double Calculator(String ss) {
		return 0;
	}
	private void setBackSpace(String bs) {
		label.setText(bs);
	}
	
	private String getBackSpace() {
		return label.getText();
	}

}
