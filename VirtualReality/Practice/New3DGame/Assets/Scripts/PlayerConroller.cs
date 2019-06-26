using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour {


    //스피드 조정변수
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float crouchSpeed;

    private float applySpeed;

    [SerializeField]
    private float jumpForce;

    //상태 변수
    private bool isRun = false;
    private bool isCrouch = false;
    private bool isGround = true;

    
    //앉았을 대 얼마나 앉을지 결정하는 변수.
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;

    //땅 착지 여부
    private CapsuleCollider capsuleCollider;

    //카메라 민감도
    [SerializeField]
    private float lookSensitivity;

    //카메라 한계
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;
    private float currentCameraRotationY = 0;

    //필요한 컴포런트
    [SerializeField]
    private Camera theCamera;



    private Rigidbody myRigid;

	// Use this for initialization
	void Start () {
        applySpeed = walkSpeed;
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        originPosY = theCamera.transform.localPosition.y;//player를 내리는게 아니라 카메라가 앉음. 
        applyCrouchPosY = originPosY;//서 있는 상태

	}
	


	// Update is called once per frame
	void Update () {
        IsGround();
        TryJump();
        TryRun();
        TryCrouch();
        Move();
        CameraRotation();
        CharacterRotation();
        CharacterRotationY();

    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position+_velocity*Time.deltaTime);

    }

    private void TryCrouch()//앉기 시도
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }

    private void Crouch()//앉기 동작
    {
        isCrouch = !isCrouch;
        if (isCrouch)
        {
            applySpeed = crouchSpeed;//앉았을 때 스피드
            applyCrouchPosY = crouchPosY;
        }
        else
        {
            applySpeed = walkSpeed;//섰을 때 스피드!
            applyCrouchPosY = originPosY;
        }

        StartCoroutine(CrouchCoroutine());
    }

    IEnumerator CrouchCoroutine()//부드러운 동작 실행
    {
        float _posY = theCamera.transform.localPosition.y;
        int count = 0;

        while (_posY != applyCrouchPosY)
        {
            count++;
            _posY = Mathf.Lerp(_posY,applyCrouchPosY,0.2f);//보관함수 (1,2,1) 1에서 2까지 1증가
            theCamera.transform.localPosition = new Vector3(0,_posY,0);
            if (count > 15)
                break;
            yield return null;
        }
        theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0f);
        
    }
    private void IsGround()//지면체크
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y+0.1f);
    }

    private void TryJump()//점프 시도
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    private void Jump()//점프
    {
        if (isCrouch)//앉은 상태에서 점프시 앉은 자세 해제
            Crouch();
        
        myRigid.velocity = transform.up * jumpForce;
    }

    private void TryRun()//달리기 시도
    {//GEtKey키가 눌러져 있는 상ㄴ태
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
        }
    }

    private void Running()//달리기 실행
    {
        if (isCrouch)
            Crouch();

        isRun = true;
        applySpeed = runSpeed;
    }

    private void RunningCancel()//달리기 취소
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    private void CharacterRotation()//좌우 캐릭터 회전
    {
        float _YRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationX = new Vector3(0f, _YRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationX));

      


    }
    private void CharacterRotationY()//상하 캐릭터 회전
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 _characterRotationY = new Vector3(_xRotation, 0f, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }

    private void CameraRotation()//카메라 회전
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX,0f,0f);

        
    }
}
