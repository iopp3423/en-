package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.GridLayout;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.SwingConstants;


public class RecordPanel extends JPanel{

	private JScrollPane scrollPane;

	public RecordPanel() {
		
		JButton log = new JButton("ㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇ");
		JButton Log = new JButton("ffff");
		JButton aog = new JButton("ffff");
		JButton bog = new JButton("ffff");
		JButton cog = new JButton("ffff");
		JButton dog = new JButton("ffff");
		JButton eog = new JButton("ffff");
		JButton fog = new JButton("ffff");
		JButton gog = new JButton("ffff");
		JButton qog = new JButton("ffff");
		JButton wog = new JButton("ffff");
		JButton eog1 = new JButton("ffff");
		JButton rog = new JButton("ffff");
		JButton tog = new JButton("ffff");
		JButton yog = new JButton("ffff");

		Log.setPreferredSize(new Dimension(170, 90));
		Log.setHorizontalAlignment(SwingConstants.RIGHT); // 가로 배치 
//		setBackground(Color.GREEN);
		setLayout(new GridLayout(0,1,1,1));
	
        add(log);
        add(Log);
        add(aog);
        add(bog);
        add(cog);
        add(dog);
        add(eog);
        add(fog);
        add(gog);
        add(qog);
        add(wog);
        add(eog);
        add(rog);
        add(tog);    
	}
	
	/*
	public void record()
	{
		JPanel recordPanel = new JPanel();
		JButton log = new JButton("ㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇ");
		JButton Log = new JButton("ffff");
		JButton aog = new JButton("ffff");
		JButton bog = new JButton("ffff");
		JButton cog = new JButton("ffff");
		JButton dog = new JButton("ffff");
		JButton eog = new JButton("ffff");
		JButton fog = new JButton("ffff");
		JButton gog = new JButton("ffff");
		JButton qog = new JButton("ffff");
		JButton wog = new JButton("ffff");
		JButton eog1 = new JButton("ffff");
		JButton rog = new JButton("ffff");
		JButton tog = new JButton("ffff");
		JButton yog = new JButton("ffff");

		Log.setPreferredSize(new Dimension(170, 90));
		Log.setHorizontalAlignment(SwingConstants.RIGHT); // 가로 배치 
//		setBackground(Color.GREEN);
		setLayout(new GridLayout(0,1,1,1));

		
		recordPanel.add(log);
		recordPanel.add(Log);
		recordPanel.add(aog);
		recordPanel.add(bog);
		recordPanel.add(cog);
		recordPanel.add(dog);
		recordPanel.add(eog);
		recordPanel.add(fog);
		recordPanel.add(gog);
		recordPanel.add(qog);
		recordPanel.add(wog);
		recordPanel.add(eog);
		recordPanel. dd(rog);
		recordPanel.add(tog);
	}
	*/
}
