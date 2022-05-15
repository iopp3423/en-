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
		
		JPanel logPanel = new JPanel(new GridLayout(14,1));
		setLayout(new BorderLayout());


		scrollPane = new JScrollPane(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		scrollPane.add(logPanel);
		logPanel.add(log);
		logPanel.add(Log);
		logPanel.add(aog);
		logPanel.add(bog);
		logPanel.add(cog);
		logPanel.add(dog);
		logPanel.add(eog1);
		logPanel.add(fog);
		logPanel.add(gog);
		logPanel.add(qog);
		logPanel.add(wog);
		logPanel.add(eog);
		logPanel.add(rog);
		//add(log);
		add(logPanel);
		//add(scrollPane);
		/*
		logPanel.add(log);
		logPanel.add(Log);
		add(logPanel);
		add(scrollPane,BorderLayout.EAST); // 패널에 스크롤 넣어
		*/

	}
}
