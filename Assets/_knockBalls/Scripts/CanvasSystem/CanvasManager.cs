﻿using System;
using System.Collections.Generic;
using _knockBalls.Scripts.Data;
using UnityEngine;

namespace _knockBalls.Scripts.CanvasSystem
{
    public class CanvasManager : MonoBehaviour
    {
        public static CanvasManager Instance { get; private set; } 
        [SerializeField] private List<CanvasController> canvasList;
        [SerializeField] private CanvasType startCanvas;

        private CanvasController _current;
        private readonly Stack<CanvasController> _history = new();

        private void Awake()
        {
            Instance ??= this;
        }

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            foreach (var canvas in canvasList)
            {
                canvas.Initialize(this);
            }
            Open(startCanvas);
        }
        
        public void Dispose()
        {
            _history.Clear();
        }
		
        public void Open(CanvasType canvasType)
        {
            if (_current)
                _history.Push(_current);

            foreach (var canvasController in canvasList)
            {
                if (canvasController.canvasType == canvasType)
                {
                    _current = canvasController;
                    _current.Open();
                }
                else
                {
                    canvasController.Close();
                }
            }
        }

        public void Back()
        {
            if (_history.Count == 0)
                return;
			
            _current.Close();

            var canvas = _history.Pop();
            _current = canvas;
            _current.Open();
        }

        public bool CanvasIsOpen(CanvasType type)
        {
            canvasList.Find(x => x.canvasType == type).TryGetComponent<Canvas>(out var canvas);

            return canvas.enabled;
        }

        public void Open(CanvasType current, List<CanvasType> canvasTypes)
        {
            if (_current)
                _history.Push(_current);
			
            foreach (var canvasController in canvasList)
            {
                if (canvasController.canvasType == current)
                    _current = canvasController;
				
                if (canvasTypes.Contains(canvasController.canvasType))
                    canvasController.Open();
                else 
                    canvasController.Close();
            }
        }
    }
}