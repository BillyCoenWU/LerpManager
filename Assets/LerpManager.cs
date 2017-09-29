using UnityEngine;
using UnityEngine.UI;
using RGSMS.Math;

public class LerpManager : MonoBehaviour
{
	[SerializeField]
	private INTERPOLATION m_interpolation = INTERPOLATION.Linear;

	[SerializeField]
	private Transform m_cube = null;

	[SerializeField]
	private Text m_text = null;
	[SerializeField]
	private Text m_textN = null;
	[SerializeField]
	private Text m_textS = null;

	[SerializeField]
	private Image m_Image = null;

	[SerializeField]
	private Vector3 m_v0 = Vector3.zero;
	[SerializeField]
	private Vector3 m_v1 = Vector3.zero;

	[SerializeField]
	private bool m_auto = false;

	private float m_velocity = 1.0f;
	private float m_time = 0.0f;

	private bool m_work = false;

	[SerializeField]
	private Sprite[] m_easingImages = null;

	private void Start ()
	{
		m_textN.text = string.Concat((1).ToString(), "/31");
		m_text.text = Easings.sFunctions[0];
		m_Image.sprite = m_easingImages[0];

		if(m_auto)
		{
			Invoke("Active", 1.0f);
		}
	}

	private void Update ()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			Minus();
		}

		if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			Plus();
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			Plus();
			Stop();
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Active();
		}

		if(!m_work)
		{
			return;
		}

		m_cube.position = Mathr.Lerp (m_v0, m_v1, m_time, m_interpolation);

		if(m_time >= 1.0f)
		{
			if(m_auto)
			{
				Next();
			}
			else m_work = false;
		}

		m_time += (Time.deltaTime * m_velocity);

		if(m_time >= 1.0f)
		{
			m_time = 1.0f;
		}

		SetTime();
	}

	public void Stop ()
	{
		m_time = 0.0f;
		m_work = false;

		SetTime();
		ResetPosition ();
	}

	private void Next ()
	{
		Plus();

		m_time = 0.0f;
		m_work = false;

		SetTime();

		Invoke("ResetPosition", 0.5f);
		Invoke("Active", 1.0f);
	}

	private void Plus ()
	{
		int i = (int)m_interpolation;
		i++;

		if(i > (int)INTERPOLATION.BounceEaseInOut)
		{
			i = 0;
		}

		m_textN.text = string.Concat((i+1).ToString(), "/31");

		m_text.text = Easings.sFunctions[i];
		m_Image.sprite = m_easingImages[i];

		m_interpolation = (INTERPOLATION)i;
	}

	private void Minus ()
	{
		int i = (int)m_interpolation;
		i--;

		if(i < 0)
		{
			i = (int)INTERPOLATION.BounceEaseInOut;
		}

		m_textN.text = string.Concat((i+1).ToString(), "/31");

		m_text.text = Easings.sFunctions[i];
		m_Image.sprite = m_easingImages[i];

		m_interpolation = (INTERPOLATION)i;
	}

	public void Active ()
	{
		m_time = 0.0f;
		m_work = true;

		SetTime();
	}

	private void SetTime ()
	{
		m_textS.text = string.Concat(m_time.ToString("0.00"), "s");
	}

	private void ResetPosition ()
	{
		m_cube.position = m_v0;
	}

	public void SetToggle (bool b)
	{
		m_auto = b;
	}

	public void SetVelocity (string velocity)
	{
		m_velocity = float.Parse(velocity);
	}
}
