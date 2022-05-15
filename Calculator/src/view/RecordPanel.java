package view;

import java.awt.Dimension;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.GridLayout;

import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JScrollPane;


public class RecordPanel extends JPanel{

	private JScrollPane scrollPane;

	public RecordPanel() {
		
		setLayout(new GridBagLayout());
		GridBagConstraints con = new GridBagConstraints();
		con.fill = GridBagConstraints.VERTICAL;
		con.weightx = 1.0;
		con.weighty = 1.0;
		scrollPane = new JScrollPane(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		//scrollPane.setPreferredSize(new Dimension(400, 500));

		add(scrollPane); // 패널에 스크롤 넣어
	}
}
