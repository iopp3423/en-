package view;


import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.SwingConstants;
import Utility.Constants;



public class RecordPanel extends JPanel{

	public JButton [] button;
	
	public RecordPanel(ActionListener printRecord) {
		
		
		button = new JButton[20];
		setLayout(new GridLayout(0,1,0,1));		
		

		for(int index=0; index<button.length; index++)
		{
			button[index] = new JButton();
			button[index].setPreferredSize(new Dimension(270, 60));
			button[index].setHorizontalAlignment(SwingConstants.RIGHT); // 오른 배치 
			button[index].setOpaque(true);//있어야 색 적용가능
			button[index].setBorderPainted(false);//있어야 색 적용가능 
			button[index].setMaximumSize(new Dimension(200,300));
			button[index].setFont(new Font("맑은 고딕", Constants.RESET, Constants.FONT_SIZE));
			if(index == Constants.RESET) button[index].setText("아직 기록이 없습니다.");
			add(button[index]);
			button[index].addActionListener(printRecord);
		}
		
		
	}
	
}
